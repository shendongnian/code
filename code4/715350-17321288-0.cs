    public class KeyCapture : MonoBehaviour {
	bool captureKey = false;
	string assignedKey = "a";
	
	// Update is called once per frame
	void Update () {
		ReassignKey();
		
		// Mouse-click = wait for next key press
		if(Input.GetButtonDown("Fire1")){
			captureKey = true;
			Debug.Log("Waiting for next keystroke");
		}
		
		// Display message for currently assigned control.
		if(Input.GetKeyDown(assignedKey)){
			Debug.Log("Action mapped to key: " + assignedKey);
		}
	}
	
	void ReassignKey(){
		if(!captureKey)return;
		
		// ignore frames without keys
		if(Input.inputString.Length <= 0)return;
	
		// Input.inputString stores all keys pressed
		// since last frame but I only want to use a single
		// character.
		string originalKey = assignedKey;
		assignedKey = Input.inputString[0].ToString();
		captureKey = false;
		
		Debug.Log("Reassigned key '" + originalKey + "' to key '" + assignedKey + "'");
	}
    }
