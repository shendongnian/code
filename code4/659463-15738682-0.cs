    void Start()
    {
        ...   
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "ShakeTrigger")
    {
        GameObject.Find("Camera").SendMessage("DoShake");  
        Debug.Log("The camera trigger has hit");
    }
    }...
