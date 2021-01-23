    IList<DateTime> starts = new List<DateTime>();
    IList<DateTime> ends = new List<DateTime>();
    DateTime breakStart1 = new DateTime(2012, 02, 15, 12, 30, 00);  // 15/02/12 12.30PM
    DateTime breakEnd1 = new DateTime(2012, 02, 15, 13, 30, 00);  // 15/02/12 01.30PM
    DateTime breakStart2 = new DateTime(2012, 02, 15, 11, 00, 00);  // 15/02/12 11.00AM
    DateTime breakEnd2 = new DateTime(2012, 02, 15, 12, 00, 00);  // 15/02/12 12.00PM
    DateTime breakStart3 = new DateTime(2012, 02, 15, 12, 00, 00);  // 15/02/12 12.00PM
    DateTime breakEnd3 = new DateTime(2012, 02, 15, 01, 00, 00);  // 15/02/12 01.00PM
    starts.Add(breakStart1);
    starts.Add(breakStart2);
    starts.Add(breakStart3);
    ends.Add(breakEnd1);
    ends.Add(breakEnd2);
    ends.Add(breakEnd3);
    List<Break> breaks = new List<Break>();
    for (int i = 0; i < starts.Count; i++)
    {
        breaks.Add(new Break()
        {
            MealStart = starts[i],
            MealEnd = ends[i]
        });
    }
    var ordered = breaks.OrderBy(s => s.MealStart);
    foreach (var ord in ordered)
    {
        System.Console.WriteLine(ord.MealStart);
        System.Console.WriteLine(ord.MealEnd);
    }
