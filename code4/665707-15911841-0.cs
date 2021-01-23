    public static class Validation
    {
    	public static bool IsValidSqlDateTimeNative(string someval)
    	{
    		DateTime testDate;
    		return DateTime.TryParse(someval, out testDate) && 
                   testDate >= SqlDateTime.MinValue.Value;
    	}
    }
