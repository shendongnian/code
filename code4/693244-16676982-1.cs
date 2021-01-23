    public static double ConvertToUnixTimestamp(DateTime value)
    {
    	var span = (value - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
    	return span.TotalSeconds;
    }
