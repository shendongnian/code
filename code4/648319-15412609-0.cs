    List<DateTime> GetDateRange(List<LockedDate> source, DateTime start, DateTime end)
    {
        if (start > end)
            throw new ArgumentException("Start must be before end");
        var ts = end - start;
        var dates = Enumerable.Range(0, ts.Days)
            .Select(i => start.AddDays(i))
            .Where(d => source.Any(ld => ld.Date == d
                || (ld.IsYearly && ld.Date.Month == d.Month && ld.Date.Day == d.Day)));
        return dates.ToList();
    }
