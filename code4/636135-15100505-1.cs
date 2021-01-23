    var breaks = new List<Break>()
                     {
                         new Break()
                             {
                                 Start = new DateTime(2012,2,15,12,30,0),
                                 End = new DateTime(2012,2,15,13,30,0)
                                 ... /// etc.
                             }
                     };
    var ordered = breaks.OrderBy(s => s.Start);
    foreach (var ord in ordered)
    {
        System.Console.WriteLine(ord.Start);
        System.Console.WriteLine(ord.End);
    }
