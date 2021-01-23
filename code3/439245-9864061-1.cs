    var lines = units.Where(l => l.Contains(userUnit1) && l.Contains(userUnit2));
    if(lines.Any())
    {
        var unit = lines.First();
        var parts = unit.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
        var result = userValue * double.Parse(parts[2]);
    }
