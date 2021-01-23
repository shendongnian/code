    private static bool IsObjectHasNeccesaryDate(YourType obj, DateTime startDate, DateTime endDate)
    {
    	return EntityFunctions.TruncateTime(obj.Date.Value) >= EntityFunctions.TruncateTime(startDate) 
    	    && EntityFunctions.TruncateTime(obj.Date.Value) <= EntityFunctions.TruncateTime(endDate);
    }
