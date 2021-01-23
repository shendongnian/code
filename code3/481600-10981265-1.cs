	private static DateTime GetNext4AM(DateTime input)
	{
		var result = new DateTime(input.Year, input.Month, input.Day, 4, 0, 0);
		if (result > input)
		{
			return result;
		}
		else
		{
			return result.AddDays(1);	
		}
	}
