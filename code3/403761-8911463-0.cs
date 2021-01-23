    protected DateTime GetStartTime()
    {
        DateTime dt=DateTime.Now;
        if (dt.Minute<30) dt.Minute=30;
        else 
        {
           dt.Minute=30;
           dt.AddMinutes(30);
        }
    
        //dt now has the upcoming half-hour border
    
        //...
    
    }
