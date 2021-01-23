    var features = new List<string>();
    var projects = new List<string>();
    foreach (var split in input.Select(v => v.Split('@')))
    {
        features.Add(split[0]);
        projects.Add(split[1]);
    }
