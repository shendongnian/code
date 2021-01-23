	private static bool IsBeforeNow(DateTime now, DateTime dateTime)
	{
		return dateTime.Month < now.Month
			|| (dateTime.Month == now.Month && dateTime.Day < now.Day);
	}
	
