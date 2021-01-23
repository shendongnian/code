    var nextFiveWeekDays = new List<DateTime>();
    var testDate = DateTime.Now.Date;
    
    while (nextFiveWeekDays.Count()<5)
    {
      if (testDate.DayOfWeek != DayOfWeek.Saturday && 
               testDate.DayOfWeek != DayOfWeek.Sunday)
         nextFiveWeekDays.Add(testDate);
         
    testDate = testDate.AddDays(1);
    }
