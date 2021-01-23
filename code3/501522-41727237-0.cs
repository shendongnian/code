    public static bool IsWorkDay(this DateTime dt)
    {
        return IsWorkDay(dt, DayOfWeek.Sunday, DayOfWeek.Saturday);
    }
    public static bool IsWorkDay(this DateTime dt, params DayOfWeek[] noneWorkDays)
    {
        return !noneWorkDays.Contains(dt.DayOfWeek);
    }
