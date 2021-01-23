    var nextFiveWeekDays = new List<DateTime>();
    var testDate = DateTime.Now.Date;
    
    while (nextFiveWeekDays.Count()<5)
    {
      switch (testDate.DayOfWeek)
      {
         case DayOfWeek.Saturday:
         case DayOfWeek.Sunday:
            break;
         default:
            nextFiveWeekDays.Add(testDate);
            break;
    
      }   
    testdate = testdate.AddDays(1);
    }
