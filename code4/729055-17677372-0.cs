    public static string LSet(string Source, int Length)
    {
    	if (Length == 0)
    	{
    		return "";
    	}
    	if (Source == null)
    	{
    		return new string(' ', Length);
    	}
    	if (Length > Source.Length)
    	{
    		return Source.PadRight(Length);
    	}
    	return Source.Substring(0, Length);
    }
    public static string RSet(string Source, int Length)
    {
    	if (Length == 0)
    	{
    		return "";
    	}
    	if (Source == null)
    	{
    		return new string(' ', Length);
    	}
    	if (Length > Source.Length)
    	{
    		return Source.PadLeft(Length);
    	}
    	return Source.Substring(0, Length);
    }
