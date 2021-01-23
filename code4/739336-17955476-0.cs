    // This is *inclusive* of both bounds
    public XYZ GetResultsByDate(DateTime fromDate, DateTime toDate)
    {
        return GetResultsByDateAndTime(fromDate.Date, toDate.Date.AddDays(1));
    }
    // This is *exclusive* of the upper bound
    public XYZ GetResultsByDateAndTime(DateTime from, DateTime to)
    {
        var results = context.Results.Where(r=> r.date >= from && r.date < to);
        ...
    }
