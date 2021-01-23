    var channelGroups = array.Select(s =>
    {
        var tokens = s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        var tsTokens = tokens[1].Split(':');
        return new Channel()
        {
            Name = tokens[0],
            Duration = new TimeSpan(
                int.Parse(tsTokens[0]),  // hours
                int.Parse(tsTokens[1]),  // minutes
                int.Parse(tsTokens[2]))  // seconds
        };
    })
    .GroupBy(c => c.Name)
    .Select(g => new
    {
        Channel = g.Key,
        Count = g.Count(),
        Average = g.Average(c => c.Duration.TotalMinutes)
    });
