    public static DateTime Now
    {
    	get
    	{
    		return DateTime.UtcNow.ToLocalTime();
    	}
    }
