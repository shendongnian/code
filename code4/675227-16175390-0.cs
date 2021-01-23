    DateTime StartDateTime = new DateTime(2013, 04, 22, 20, 37, 28);
    DateTime EndDateTime = new DateTime(2013, 04, 25, 22, 55, 20);
    
    DateTime startTime = StartDateTime;
    // calculate first break time
    DateTime breakTime = StartDateTime.Date.AddHours(6);
    if (breakTime < StartDateTime) {
      breakTime = breakTime.AddDays(1);
    }
    while (breakTime < EndDateTime) {
      Console.WriteLine("{0} - {1}", startTime, breakTime);
      // move to next day
      startTime = breakTime;
      breakTime = breakTime.AddDays(1);
    }
    Console.WriteLine("{0} - {1}", startTime, EndDateTime);
