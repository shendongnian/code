    var startTime = new DateTime(2012, 7, 7);
    var stopTime = new DateTime(2012, 7, 31);
    do {
        Console.WriteLine(startTime.ToShortDate());
        startTime.AddDays(7);
    } while ( startTime < stopTime );
