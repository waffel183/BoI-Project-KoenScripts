using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int healthPoints;
    private int startHP = 100;
    public bool notDead = true;

    EnemyFinalStage finalStage;
    public GameObject feet;

	// Use this for initialization
	void Start () {
        healthPoints = startHP;
        finalStage = feet.GetComponent<EnemyFinalStage>();
        finalStage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("E_Health: " + healthPoints);
        if(healthPoints < startHP * 0.15f)
        {
            Debug.Log("Enemy DEAD!");
        }
        if(healthPoints < 30 || Input.GetKey(KeyCode.K))
        {
            finalStage.enabled = true;
            finalStage.StartCoroutine(finalStage.DetachAndAttack());
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "FriendlyBullet")
        {
            healthPoints--;
        }
    }

    public float ReturnHealth()
    {
        return healthPoints*1.0f;
    }
}
