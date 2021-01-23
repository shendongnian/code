    public static IEnumerable<DateTime> GetRangeTo(this DateTime start, DateTime end)
    {
        DateTime date = start;
    
        while(date <= end)
        {
            yield return date;
            date = date.AddDays(1);
        }
    }
