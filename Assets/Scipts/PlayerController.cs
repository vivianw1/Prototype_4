using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public float speed = 5.0f;
    public bool hasPowerup = false;
    private float, PowerupDtrength  = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        playerRb.AddForce(focalPoint.transform.forward * forwardInput* speed); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerup=true;
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRountine());
        }
    }
    
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSceonds(7);
        hasPowerup = false;
    }
    private void  OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")&&hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponenet<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody Addforce(awayFromPlayer * powerupStrength,ForceMode.Impulse);
            Debug.Log("Collided with:" + collision.gameObject.name + "with powerup set to" + hasPowerup);
        }
    
    }

}

