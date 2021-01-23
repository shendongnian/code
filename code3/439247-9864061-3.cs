    String path = @"C:\Users\Sam Smith\Desktop\convert.txt";
    var lines = System.IO.File.ReadLines(path)
               .Where(l => l.Contains(userUnit1) && l.Contains(userUnit2));
    if(lines.Any())
    {
        var unit = lines.First();
        var parts = unit.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
        var result = userValue * double.Parse(parts[2]);
    }
