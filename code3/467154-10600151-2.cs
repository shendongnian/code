    var numberGroups = numbers.GroupBy(i => i)
                       .Select(grp => new{
                           number  = grp.Key,
                           total   = grp.Count(),
                           average = grp.Average(),
                           minimum = grp.Min(),
                           maximum = grp.Max()
                       })
                       .ToArray();
    foreach (var numInfo in numberGroups)
    {
        var number = numInfo.number;
        // ...
        var maximum = numInfo.maximum;
    }
