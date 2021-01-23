    public static IEnumerable<Datetime> DaysOfMonth(
        this DateTime any,
        DayOfWeek day)
    {
        // start at first of month
        var candidate = new DateTime(any.Year, any.Month, 1);
        var offset = (int)day - (int)candidate.DayOfWeek;
        
        if (offset < 0)
        {
            offset += 7
        }
        candidate = candidate.AddDays(offset);
        while (cadidate.Month == any.Month)
        {
            yield return candidate;
            candidate = candidate.AddDays(7.0)
        }
    }
