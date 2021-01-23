    var groups = list.Select(o => new
    {
        Order = o,
        DayPart = o.time.TimeOfDay.TotalHours <= 9 ? 1
           : o.time.TimeOfDay.TotalHours > 9  && o.time.TimeOfDay.TotalHours <= 14 ? 2
           : o.time.TimeOfDay.TotalHours > 14 && o.time.TimeOfDay.TotalHours <= 18 ? 3 : 4
    })
    .GroupBy(x => x.DayPart)
    .OrderBy(g => g.Key);
    var first = groups.ElementAt(0);  
    var second = groups.ElementAt(1);
    // ...
