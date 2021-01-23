    public static DateTime AddWorkingDays(DateTime start, int workingDays, IEnumerable<DateTime> holidays)
    {
        var dict = new HashSet<DateTime>(holidays);
        DateTime date;
        for (date = start; workingDays > 0; date = date.AddDays(1))
        {
            if (!dict.Contains(date))
            {
                --workingDays;
            }
        }
        return date;
    }
