    private static bool IsObjectHasNeccesaryDate(YourType obj, DateTime startDate, DateTime endDate)
    {
    	return EntityFunctions.TruncateTime(x.Date.Value) >= EntityFunctions.TruncateTime(startDate) 
    	    && EntityFunctions.TruncateTime(x.Date.Value) <= EntityFunctions.TruncateTime(endDate);
    }
