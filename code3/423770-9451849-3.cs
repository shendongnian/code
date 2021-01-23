    // DateTime(2012, 2, 1) corresponds to Year 2012, Month February, Day 1
    Dictionary<DateTime, DateTime> dateTimes = GetWeeklyDateTimes(new DateTime(2012, 2, 1), new DateTime(2012, 2, 29), DayOfWeek.Monday, DayOfWeek.Sunday);
    foreach (KeyValuePair<DateTime, DateTime> entry in dateTimes)
    {
        Trace.WriteLine(entry.Key.ToString() + "     " + entry.Value.ToString());
    }
