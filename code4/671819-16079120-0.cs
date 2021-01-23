    var input = new List<TimeSpan>
    {
        new TimeSpan(15, 45, 00),
        new TimeSpan(15, 30, 54),
        new TimeSpan(00, 12, 14),
        new TimeSpan(01, 13, 47),
        new TimeSpan(05, 48, 23),
        new TimeSpan(12, 00, 47),
    };
    
    var query = from hour in Enumerable.Range(0, 24)
                join item in input on hour equals item.Hours into g
                select new
                {
                    CallTime = hour,
                    CallCount = g.Count(),
                };
    
    foreach (var x in query)
    {
        Console.WriteLine("{0:00} {1}", x.CallTime, x.CallCount);
    }
