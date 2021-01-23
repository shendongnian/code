    string startTime = "7:00 AM";
    string endTime = "2:00 PM";
    TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
    Console.WriteLine(duration);
    Console.ReadKey();
