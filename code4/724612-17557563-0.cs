    DateTime date = DateTime.Now;
    TimeSpan startTime = new TimeSpan(18, 00, 00);
    TimeSpan endTime = new TimeSpan(19, 00, 00);
    if (date.DayOfWeek.Equals(DayOfWeek.Saturday) && 
                      date.TimeOfDay >= startTime && 
                      date.TimeOfDay <= endTime )
        //Do the operation that you want
