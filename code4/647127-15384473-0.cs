    DateTime startTime = DateTime.Now;
    Thread.Sleep(5000);
    DateTime endTime = DateTime.Now;
    TimeSpan duration = endTime.Subtract(startTime);
    Console.WriteLine("Run took {0:00}:{1:00}:{2:00}",
            (int)duration.TotalHours, duration.Minutes, duration.Seconds);
