	// some testdata
	var datesList = Enumerable.Range(0, 8).Select (e => DateTime.Now.AddDays(7 * e)).ToList();
	
	Func<DateTime, int> weekProjector = d =>
		CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
	var weeks = datesList.GroupBy(weekProjector).ToList();
