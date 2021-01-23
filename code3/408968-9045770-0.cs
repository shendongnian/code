    var startTime = DateTime.Parse("2012-01-28 18:00:00");
    var endTime = startTime.AddHours(3);
    while (startTime <= endTime)
    {
      System.Console.WriteLine(startTime.ToShortTimeString());
      startTime = startTime.AddMinutes(30);
    }
