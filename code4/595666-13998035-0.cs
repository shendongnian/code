    var groups = Test
        .GroupBy(g => g.Category)
        .Select(g => new
                     {
                         Category = g.Key,
                         Items = g.OrderBy(i => i.Order)
                     })
        .OrderBy(g => g.Category)
        .SelectMany(g => g.Items)
        .ToList();
