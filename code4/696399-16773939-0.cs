       public class Triggers : MonoBehaviour
    {
    	IEnumerator wait (float seconds)
    	{
    		Debug.Log ("In wait");
    		GameObject go = GameObject.Find ("Cube");
    		go.SetActive(false);
    		yield return new WaitForSeconds(seconds);
    		Debug.Log ("after wait");
    		go.SetActive (true);
    	}
           
    	void OnTriggerEnter (Collider _collider)
    	{
    		Debug.Log ("Destroy");
    		Debug.Log ("Before wait");
    		StartCoroutine (wait (5));
    		Debug.Log ("activate");
         
    	}
