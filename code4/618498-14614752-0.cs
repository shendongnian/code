    public int Total { get; set; }
    public void DoSomething(int x)
    {
        if(x == 1)
        {
            Total = 100;
            return;
        }
        
        if(x == 2)
        {
           Total = 200;
           return;
        }
    }
    
