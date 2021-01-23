    public readonly static customer cust;
    
    //Allowed
    static Program()
    {
        cust = new customer(); 
    }
    
    //Not Allowed
    public Program()
    {
        cust = new customer();
    }
