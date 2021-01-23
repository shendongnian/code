    	/// <summary>
		/// Calculate age in years relative to months and days, for example Peters age is 25 years 2 months and 10 days
		/// </summary>
		/// <param name="startDate">The date when the age started</param>
		/// <param name="endDate">The date when the age ended</param>
		/// <param name="calendar">Calendar used to calculate age</param>
		/// <param name="years">Return number of years, with considering months and days</param>
		/// <param name="months">Return calculated months</param>
		/// <param name="days">Return calculated days</param>
		public static bool GetAge(this DateTime startDate, DateTime endDate, Calendar calendar, out int years, out int months, out int days)
		{
			if (startDate > endDate)
			{
				years = months = days = -1;
				return false;
			}
			years = months = days = 0;
			days += calendar.GetDayOfMonth(endDate) - calendar.GetDayOfMonth(startDate);
			// When negative select days of last month
			if (days < 0)
			{
				days += calendar.GetDaysInMonth(calendar.GetYear(startDate), calendar.GetMonth(startDate));
				months--;
			}
			months += calendar.GetMonth(endDate) - calendar.GetMonth(startDate);
			// when negative select month of last year
			if (months < 0)
			{
				months += calendar.GetMonthsInYear(calendar.GetYear(startDate));
				years--;
			}
			years += calendar.GetYear(endDate) - calendar.GetYear(startDate);
			return true;
		}
