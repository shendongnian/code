    public static bool IsWeekend(this DateTime date)
    {
        return (date.DayOfWeek == DayOfWeek.Saturday) ||
               (date.DayOfWeek == DayOfWeek.Sunday)
    }
