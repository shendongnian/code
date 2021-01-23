    var start = DateTime.Parse("08/17/2012");
    var end = DateTime.Parse("09/17/2012");
    int numberOfDays = end.Subtract(start).Days + 1;
    var daysOfWeek = new[] { DayOfWeek.Tuesday, DayOfWeek.Thursday };
    
    var dates = Enumerable.Range(0, numberOfDays)
                          .Select(i => start.AddDays(i))
                          .Where(d => daysOfWeek.Contains(d.DayOfWeek));
