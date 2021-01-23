    public static class ExtenstionMethods
    {
    	public static string ToEventDate(this DateTime date)
    	{
    		return date.ToString("yyyyMM");
    	}
    }
