    private DateTime targetDate = DateTime.Now.AddMinutes(1);
    
    public void Timer() 
    {   
        DateTime now = DateTime.Now;
        if (now > targetDate) { 
            targetDate = now.AddMinutes(1); 
            Vote(); 
        } 
    } 
