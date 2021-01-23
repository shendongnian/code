    var channelGroups = array.Select(s =>
    {
        var tokens = s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        return new Channel()
        {
            Name = tokens[0],
            Durarion = TimeSpan.ParseExact(tokens[1], "t", System.Globalization.CultureInfo.InvariantCulture)
        };
    })
    .GroupBy(c => c.Name)
    .Select(g => new
    {
        Channel = g.Key,
        Count = g.Count(),
        Average = g.Average(c => c.Durarion.Minutes)
    }).ToList();
