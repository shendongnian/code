	static DateTime GetLastDayOfWeek(DateTime date)
	{
		var lastDayOfWeek = date.AddDays((DayOfWeek.Saturday - date.DayOfWeek + 7) % 7);
		if (lastDayOfWeek.Year != date.Year)
			lastDayOfWeek = new DateTime(date.Year, 12, 31);
		return lastDayOfWeek;
	}
