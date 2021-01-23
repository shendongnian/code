    {
        DateTime lastMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
        DateTime? date = GetDate(lastMonth.Month, lastMonth.Year, DayOfWeek.Thursday, 2);
    }
    private static DateTime? GetDate(int month, int year, DayOfWeek dayOfWeek, int which)
    {
        DateTime firstOfMonth = new DateTime(year, month, 1);
        DateTime date;
        for (date = firstOfMonth; date.DayOfWeek != dayOfWeek; date = date.AddDays(1))
            ;
        date = date.AddDays(7 * (which - 1));
        return date.Month == month && date.Year == year ? (DateTime?)date : null;
    }
