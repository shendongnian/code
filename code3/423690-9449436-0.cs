    private DateTime targetDate = DateTime.Now + TimeSpan.FromMinutes(1);
    
    public void Timer() 
    {   
        DateTime now = DateTime.Now;
        if (now > targetDate) { 
            targetDate = now.AddMinutes(1); 
            Vote(); 
        } 
    } 
