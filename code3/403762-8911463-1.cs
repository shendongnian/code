    protected DateTime GetStartTime()
    {
        DateTime dt=DateTime.Now;
        if (dt.Minute<30) 
        {
            dt.AddMinutes(30-dt.Minute);
        }
        else 
        {
            dt.AddMinutes(60-dt.Minute);
        }
    
        //dt now has the upcoming half-hour border
    
        //...
    
    }
