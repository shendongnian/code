    public static GetStartOfWeek(DateTime value)
    {
        // Get rid of the time part first...
        value = value.Date;
        int daysIntoWeek = (int) value.DayOfWeek;
        return value.PlusDays(-daysIntoWeek);
    }
