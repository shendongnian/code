    public static class DateTimeExtensions
    {
        public static string ToFinancialYear(this DateTime dateTime)
    	{
    		return "Financial Year " + (dateTime.Month >= 4 ? dateTime.Year + 1 : dateTime.Year);
    	}
    	
    	public static string ToFinancialYearShort(this DateTime dateTime)
    	{
    		return "FY" + (dateTime.Month >= 4 ? dateTime.AddYears(1).ToString("yy") : dateTime.ToString("yy"));
    	}
    }
