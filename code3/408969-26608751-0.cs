     var startTime = DateTime.Parse("10:00:00");
    
        var endTime = DateTime.Parse("17:00:00");
    while (startTime <= endTime)
    {
      System.Console.WriteLine(startTime.ToShortTimeString());
      startTime = startTime.AddMinutes(30);
    }
