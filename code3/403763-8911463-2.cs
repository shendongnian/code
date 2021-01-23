    protected DateTime GetStartTime()
    {
        DateTime dt=DateTime.Now;
        if (dt.Minute<30) 
        {
            dt=dt.AddMinutes(30-dt.Minute);
        }
        else 
        {
            dt=dt.AddMinutes(60-dt.Minute);
        }
    
        //dt now has the upcoming half-hour border
    
        //...
    
    }
