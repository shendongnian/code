    public static DateTime getNextWeekDaysDate(String englWeekDate)
    {
        var desired = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), englWeekDate);
        var current = DateTime.Today.DayOfWeek;
        int c = (int)current;
        int d = (int)desired;
        int n = (7 - c + d);
        return DateTime.Today.AddDays((n >= 7) ? n % 7 : n);
    }
