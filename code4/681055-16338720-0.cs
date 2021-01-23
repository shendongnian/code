    public IEnumerable<string> GetMonthsOfYear(DateTime startDate, TimeSpan timeSpan)
    {
        var end = startDate.Add(timeSpan);
    
        for (DateTime time = startDate; time <= end; time = time.AddMonths(1))
        {
            yield return time.ToString("MMMM, yyyy");
        }
    }
