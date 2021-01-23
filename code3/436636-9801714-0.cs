    public static DateTime FirstDateOfWeek(int year, int weekOfYear)
    {
    	DateTime jan1 = new DateTime(year, 1, 1);
    	int daysOffset = Convert.ToInt32(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek) - Convert.ToInt32(jan1.DayOfWeek);
    	DateTime firstWeekDay = jan1.AddDays(daysOffset);
    	System.Globalization.CultureInfo curCulture = System.Globalization.CultureInfo.CurrentCulture;
    	int firstWeek = curCulture.Calendar.GetWeekOfYear(jan1, curCulture.DateTimeFormat.CalendarWeekRule, curCulture.DateTimeFormat.FirstDayOfWeek);
    	if (firstWeek <= 1) {
    		weekOfYear -= 1;
    	}
    	return firstWeekDay.AddDays(weekOfYear * 7);
    }
