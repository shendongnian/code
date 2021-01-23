    public static IEnumerable<DateTime> FilterDates(IEnumerable<DateTime> dates, DateMask mask)
    {
        var query = dates;
        if (mask.Year.HasValue)
            query = query.Where(date => date.Year == mask.Year);
        if (mask.Month.HasValue)
            query = query.Where(date => date.Month == mask.Month);
        if (mask.Day.HasValue)
            query = query.Where(date => date.Day == mask.Day);
        return query;
    }
