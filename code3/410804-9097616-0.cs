    private DateTime GetMonthStart(DateTime dt)
    {
        return new DateTime(dt.Year, dt.Month, 1);
    }
    private DateTime GetMonthEnd(DateTime dt)
    {
        return new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
    }
