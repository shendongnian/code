    public static DateTime GetNextWorkDay(DateTime date)
    {
        DateTime next = date.AddDays(1);
        if (next.DayOfWeek == DayOfWeek.Saturday)
            return next.AddDays(2);
        else if (next.DayOfWeek == DayOfWeek.Sunday)
            return next.AddDays(1);
        else
            return next;
    }
