    var times = new[]
                    {
                        new DateTime(2012, 5, 10, 7, 00, 0),
                        new DateTime(2012, 5, 10, 7, 30, 0),
                        new DateTime(2012, 5, 10, 7, 30, 0),
                        new DateTime(2012, 5, 10, 8, 00, 0),
                        new DateTime(2012, 5, 10, 8, 00, 0),
                        new DateTime(2012, 5, 10, 8, 30, 0),
                        new DateTime(2012, 5, 10, 8, 30, 0),
                        new DateTime(2012, 5, 10, 9, 00, 0),
                        new DateTime(2012, 5, 10, 9, 00, 0),
                        new DateTime(2012, 5, 10, 9, 30, 0)
                    };
    var result = CutTimes(times);
    foreach (var time in result)
    {
        Console.WriteLine(time);
    }
