    public static IEnumerable<DateTime> GetAlternatingWeekDay(DateTime startingDate)
    {
        for (int i = 1; ; i++)
        {
            yield return startingDate.AddDays(14*i);
        }
    }
