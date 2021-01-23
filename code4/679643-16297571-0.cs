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
   
    private void DOit() // Note: No parameters here!
    {  
        // use setUser and setPass directly here, like:
        var user = setUser;
        Do some stuff...
    }
