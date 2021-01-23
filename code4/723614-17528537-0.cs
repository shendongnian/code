    public IEnumerable<DateTime> GetHoursBetween(DateTime start, DateTime end)
    {
        DateTime first = start.Date.AddHours(start.Hour);
        for (DateTime dateTime = first; dateTime <= end; dateTime = dateTime.AddHours(1))
        {
            yield return dateTime;
        }
    }
