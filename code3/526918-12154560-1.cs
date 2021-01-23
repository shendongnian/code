    for (var i = 0; i < 7; i++)
    {
        if (fromDate.AddDays(i).DayOfWeek == DayOfWeek.Monday)
        {
            fromDate = fromDate.AddDays(i);
        }
    }
