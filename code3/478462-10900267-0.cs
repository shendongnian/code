    public static DateTime Now
    {
    	get
    	{
    		DateTime utcNow = DateTime.UtcNow;
    		bool isAmbiguousDst = false;
    		long ticks = TimeZoneInfo.GetDateTimeNowUtcOffsetFromUtc(utcNow, out isAmbiguousDst).Ticks;
    		long num = utcNow.Ticks + ticks;
    		if (num > 3155378975999999999L)
    		{
    			return new DateTime(3155378975999999999L, DateTimeKind.Local);
    		}
    		if (num < 0L)
    		{
    			return new DateTime(0L, DateTimeKind.Local);
    		}
    		return new DateTime(num, DateTimeKind.Local, isAmbiguousDst);
    	}
    }
