    static IEnumerable<string> InclusiveMonths(DateTime start, DateTime end)
    {
        var startMonth = new DateTime(start.Year, start.Month, 1);
        var endMonth = new DateTime(end.Year, end.Month, 1);
        for (var current = startMonth; current <= endMonth; current = current.AddMonths(1))
            yield return current.ToString("M/yyyy");
    }
    // usage
    foreach (var mmyyyy in InclusiveMonths(begDate, endDate))
    {
        Console.WriteLine(mmyyyy);
    }
    var allMonths = string.Join(", ", InclusiveMonths(begDate, endDate));
