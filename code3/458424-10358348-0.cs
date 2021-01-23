    DateTime date = new DateTime(2012,12,04);
    DateTime time = new DateTime(1,1,1,11,20,30);
    DateTime combined = date.AddSeconds(TimeSpan.Parse(time.ToShortTimeString()).TotalSeconds);
    Console.WriteLine(date);
    Console.WriteLine(time);
    Console.WriteLine(combined);
    04.12.2012 00:00:00
    01.01.0001 11:20:30
    04.12.2012 11:20:00
