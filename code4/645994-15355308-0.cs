    DateTime startDate = new DateTime(2013, 03, 01);
    DateTime endDate = DateTime.Today; // 12 March 2013
    int totalDays = 0;
    while (startDate <= endDate)
    {
        if (startDate.DayOfWeek == DayOfWeek.Saturday
            || startDate.DayOfWeek == DayOfWeek.Sunday)
        {
            startDate = startDate.AddDays(1);
            continue;
        }
        startDate = startDate.AddDays(1);
        totalDays++;
    }
    Console.WriteLine("Total days exculding weekends: {0}", totalDays);
