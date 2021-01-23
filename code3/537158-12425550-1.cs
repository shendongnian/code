    DateTime startDate = new DateTime(2011, 01, 01);
    DateTime endDate = new DateTime(2011, 01, 20);
    string dayName = "sunday";
    DayOfWeek dow;
    Enum.TryParse(dayName, true, out dow);
    List<DateTime> list = new List<DateTime>();
    for (DateTime runDate = startDate; runDate <= endDate; runDate = runDate.AddDays(1))
    {
        if (runDate.DayOfWeek == dow)
            list.Add(runDate);
    }
