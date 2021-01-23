    public static IEnumerable<Datetime> DaysOfMonth(
        this DateTime any,
        DayOfWeek day)
    {
        // start at first of month
        var candidate = new DateTime(any.Year, any.Month, 1);
        var offset = ((int)day) - ((int)candidate.DayOfWeek);
        
        if (offset < 0)
        {
            offset += 7
        }
        for (
            var d = candidate.AddDays(offset);
            d.Month == any.Month; 
            d = d.AddDays(7.0))
        {
            if (d.Month == any.Month)
            {
                yield return d;
            }
        }
    }
