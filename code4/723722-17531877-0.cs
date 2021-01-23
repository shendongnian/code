    // Setup    
    DateTime startDate = DateTime.Parse("7/1/2013");
    DateTime endDate = DateTime.Parse("7/31/2013");
    
    // Execute
    while (startDate < endDate)
    {
        if (startDate.DayOfWeek == DayOfWeek.Sunday)
        {
            yield return startDate;
        }
        startDate = startDate.AddDays(1);
    }
