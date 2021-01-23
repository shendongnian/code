    public static bool TimeBetween(DateTime check, DateTime start, DateTime end, bool inclusive = true)
	{
		var from = new DateTime(check.Year, check.Month, check.Day, 
            start.Hour, start.Minute, start.Second, start.Millisecond);
		var to = new DateTime(check.Year, check.Month, check.Day, 
            end.Hour, end.Minute, end.Second, end.Millisecond);
		
		if (inclusive)
			return from <= check && to >= check;
		
		return from < check && to > check;
	}
