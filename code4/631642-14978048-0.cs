    var itemAmounts = items.GroupBy(i => i, new Item())
        .Select(g => new Item { 
            ID = g.First().ID, 
            Name = g.First().Name, 
            Amount = g.Count()
        })
        .ToList();
