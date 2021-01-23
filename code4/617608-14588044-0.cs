    if (!table.TryGetValue(x, out x1))
    {
        x1 = Regex.Split(x, @"([0-9]+|\.)");
        table.Add(x, x1);
    }
    if (!table.TryGetValue(y, out y1))
    {
        y1 = Regex.Split(y, @"([0-9]+|\.)");
        table.Add(y, y1);
    }
