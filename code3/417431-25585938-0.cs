    /// <summary>
    /// Returns all ticks, milliseconds or seconds since 1970.
    /// 
    /// 1 tick = 100 nanoseconds
    /// 
    /// Samples:
    /// 
    /// Return unit   	value decimal           length     	value hex 		length
    /// --------------------------------------------------------------------------
    /// ticks           14094017407993061       17          3212786FA068F0  14
    /// milliseconds    1409397614940           13          148271D0BC5     11
    /// seconds         1409397492              10          5401D2AE        8
    ///
    /// </summary>
    public static string TickIdGet(bool getSecondsNotTicks, bool getMillisecondsNotTicks, bool getHexValue)
    {
    	string id = string.Empty;
    
    	DateTime historicalDate = new DateTime(1970, 1, 1, 0, 0, 0);
    
    	if (getSecondsNotTicks || getMillisecondsNotTicks)
    	{
    		TimeSpan spanTillNow = DateTime.UtcNow.Subtract(historicalDate);
    
    		if (getSecondsNotTicks)
    			id = String.Format("{0:0}", spanTillNow.TotalSeconds);
    		else
    			id = String.Format("{0:0}", spanTillNow.TotalMilliseconds);
    	}
    	else
    	{
    		long ticksTillNow = DateTime.UtcNow.Ticks - historicalDate.Ticks;
    		id = ticksTillNow.ToString();
    	}
    
    	if (getHexValue)
    		id = long.Parse(id).ToString("X");
    
    	return id;
    }
