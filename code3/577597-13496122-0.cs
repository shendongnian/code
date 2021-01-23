    var cheapestPrice = parts.Min(p => p.Price);
    var list = parts.Select(p => new { 
        Part = p,
        DiffPercentage = (p.Price / cheapestPrice) * 100
    });
    foreach (var p in list)
        Console.WriteLine("{0}: {1},{2}%", p.Part.PartNo, p.Part.Price, p.DiffPercentage);
