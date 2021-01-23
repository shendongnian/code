	public static void GetPeriod(string selected_period, out DateTime start, out DateTime end)
	{
		switch (selected_period)
		{
			case "last year":
				start = new DateTime(DateTime.Today.Year - 1, 1, 1);
				end = new DateTime(DateTime.Today.Year, 1, 1);
				break;
			case "this year":
				start = new DateTime(DateTime.Today.Year, 1, 1);
				end = new DateTime(DateTime.Today.Year + 1, 1, 1).AddDays(-1);
				break;
			case "last month":
				start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
				end = new DateTime(DateTime.Today.Year + 1, DateTime.Today.Month, 1).AddDays(-1);
				break;
			case "this month":
				start = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
				end = new DateTime(DateTime.Today.Year + 1, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);
				break;
			case "last week":
				start = DateTime.Today.AddDays(-7);
				while (start.DayOfWeek != DayOfWeek.Sunday)
					start = start.AddDays(-1);
				end = start.AddDays(6);
				break;
			case "this week":
				start = DateTime.Today;
				while (start.DayOfWeek != DayOfWeek.Sunday)
					start = start.AddDays(-1);
				end = start.AddDays(6);
				break;
		}
	}
