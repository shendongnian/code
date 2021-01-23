    var channelGroups = array.Select(s =>
    {
        var tokens = s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        return new Channel()
        {
            Name = tokens[0],
            Durarion = new TimeSpan(
                int.Parse(tokens[1].Split(':')[0]),  // hours
                int.Parse(tokens[1].Split(':')[1]),  // minutes
                int.Parse(tokens[1].Split(':')[2]))  // seconds
        };
    })
    .GroupBy(c => c.Name)
    .Select(g => new
    {
        Channel = g.Key,
        Count = g.Count(),
        Average = g.Average(c => c.Durarion.TotalMinutes)
    });
