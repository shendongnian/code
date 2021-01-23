    private string user1;
    private string pass1;
    public string setUser
    {
        set { user1 = value ; }
    }
    public string setPass
    {
        set { pass1 = value; }
    }
   
    // New method, just to call the other one:
    private void DOit() 
    {  
        // Just call the original method, with 
        // the properties as parameters:
        DOit(setUser, setPass);
    }
    // Your original method:
    private void DOit(string uName, string pWord) 
    {  
        Do some stuff...
    }
