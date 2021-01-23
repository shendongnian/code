    var priceGroups = data.GroupBy(x => ranges.FirstOrDefault(r => r > x.Price))
                          .Select(g => new { Price = g.Key, Count = g.Count() })
                          .ToList();
    
    var grouped = ranges.Select(r => new
    {
        Price = r,
        Count = priceGroups.Where(g => g.Price > r || g.Price == 0).Sum(g => g.Count)
    });
