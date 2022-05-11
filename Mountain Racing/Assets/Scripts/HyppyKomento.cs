using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyppyKomento : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    private bool HyppyPainikettaPainettu;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hyppykomento
        if (Input.GetKeyDown(KeyCode.J))
        {
            HyppyPainikettaPainettu = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }
    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1)
        {
            return;
        }

        if (HyppyPainikettaPainettu)
        {
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            HyppyPainikettaPainettu = false;
        }

        // rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    }

}