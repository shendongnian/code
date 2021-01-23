    public static IEnumerable<Datetime> DaysOfMonth(
        this DateTime dayOfMonth,
        DayOfWeek day)
    {
        // start at first of month
        var dayCandidate = new DateTime(dayOfMonth.Year, dayOfMonth.Month, 1);
        while (dayCandidate.DayOfWeek != day)
        {
            dayCandidate = dayCandidate.AddDays(1.0);
        }
        for (var d = dayCandidate; d.Month == dayOfMonth.Month; d = d.AddDays(7.0))
        {
            if (d.Month == dayOfMonth.Month)
            {
                yield return d;
            }
        }
    }
