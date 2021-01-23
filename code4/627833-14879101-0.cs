    static IEnumerable<string> InclusiveMonths(DateTime start, DateTime end)
    {
        do
        {
            yield return start.ToString("MM/yyyy");
            start = start.AddMonths(1);
        } while (start <= end);
    }
    // usage
    foreach (var mmyyyy in InclusiveMonths(begDate, endDate))
    {
        Console.WriteLine(mmyyyy);
    }
    var allMonths = string.Join(", ", InclusiveMonths(begDate, endDate));
