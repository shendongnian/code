    public static IEnumerable<DateTime> GetDates(DateTime startDate, DateTime endDate
        , TimeSpan interval)
    {
        for (DateTime date = startDate; date < endDate; date.Add(interval))
        {
            yield return date;
        }
    }
