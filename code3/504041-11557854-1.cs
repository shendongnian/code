    private static DateTime GetDate(DateTime todayDate, DayOfWeek dayofweek)
    {
        while (todayDate.DayOfWeek != dayofweek)
        {
            todayDate = todayDate.AddDays(-1);
        }
        return todayDate;
    }
