    DateTime startDate = new DateTime(2011, 1, 1);
    DateTime endDate = new DateTime(2011, 1, 20);
    
    while (startDate < endDate)
    {
       if (startDate.DayOfWeek == DayOfWeek.Sunday)
       {
          // Do something
       }
    
       startDate = startDate.AddDays(1);
    }
