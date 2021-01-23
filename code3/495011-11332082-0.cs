    public static DateTime Round10(this DateTime value)
    {   
        var ticksIn10Mins = TimeSpan.FromMinutes(10).Ticks;
        DateTime dtReturn = (value.Ticks % ticksIn10Mins == 0) ? value : new DateTime((value.Ticks / ticksIn15Mins + 1) * ticksIn10Mins);
        if(dtReturn > DateTime.Now())
        {
            return dtReturn.AddMinutes(-10); 
        } else {
            return dtReturn;
        }
    }
    Response.Cache.SetLastModified(Round10(DateTime.Now);
