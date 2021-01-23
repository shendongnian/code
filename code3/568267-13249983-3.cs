    public static DateTime UtcNow
    {
    	get
    	{
    		long systemTimeAsFileTime = DateTime.GetSystemTimeAsFileTime();
    		return new DateTime((ulong)(systemTimeAsFileTime + 504911232000000000L | 4611686018427387904L));
    	}
    }
