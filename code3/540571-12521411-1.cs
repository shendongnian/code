    string startTime = "7:00";
    string endTime = "14:00";
    TimeSpan duration = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
    Console.WriteLine(duration);
    Console.ReadKey();
