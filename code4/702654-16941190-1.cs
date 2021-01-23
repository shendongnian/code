    void Update()
    {
        if (trigger == true)
            transform.Translate(Vector3.right * Time.deltaTime); //This moves the GameObject to the right
    }
     
    void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 50, 50), "Dance"))
            {  
               StartCoroutine(DoTheDance());
            }
        }
     public IEnumerator DoTheDance() {
        trigger = false;
        yield return new WaitForSeconds(3f); // waits 3 seconds
        trigger = true; // will make the update method pick up 
     }
