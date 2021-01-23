    public long GetEpochTime(DateTime dt) 
    { 
        var ts = dt.Subtract(Convert.ToDateTime("1/1/1970 8:00:00 AM")); 
        return ((((((ts.Days * 24) + ts.Hours) * 60) + ts.Minutes) * 60) + ts.Seconds); 
    } 
   
