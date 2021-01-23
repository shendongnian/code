    public static class CustomFunctions
    {
    	public static DateTime GetFirstDayOfMonth(DateTime date)
    	{
    		return new DateTime(date.Year, date.Month, 1);
    	}
    }
