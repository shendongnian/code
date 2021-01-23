    List<DateTime> times = new List<DateTime>();
    
    Random rnd = new Random();
    int hourCount = (24 * 60) - 1;
    
    DateTime dtBase = DateTime.Parse("01/01/2012 12:00 AM");
    DateTime dtTest = dtBase.AddMinutes(rnd.Next(0, hourCount));
    
    Console.WriteLine("Base: " + dtBase.ToString());
    Console.WriteLine("Test: " + dtTest.ToString());
    Console.WriteLine();
    
    for (int i = 0; i < 24; i++) {
        times.Add(dtBase.AddMinutes(rnd.Next(0, hourCount)));
    }
    
    times.Sort();
    
    TimeSpan lastSpan = TimeSpan.MaxValue;
    DateTime dtMatch = DateTime.Now;
    
    foreach (DateTime dt in times) {
        Console.Write(" " + dt.ToString());
        var diff = (dtTest - dt).Duration();
        if (diff < lastSpan) {
            lastSpan = diff;
            dtMatch = dt;
        }
        Console.WriteLine();
    }
    
    Console.WriteLine();
    Console.WriteLine("Closest match to {0:hh:mm tt} => {1:hh:mm tt} ({2})", dtTest, dtMatch, lastSpan);
