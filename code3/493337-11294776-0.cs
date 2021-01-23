    var result = dbContext.Prices
        .GroupBy(p => new {p.ItemName, p.ItemTypeName)
        .Select(g => new Item
                         {
                             ItemName = g.Key.ItemName,
                             ItemTypeName = g.Key.ItemTypeName,
                             Prices = g.Select(p => new Price 
                                                        {
                                                            Price = p.Price
                                                        }
                                               ).ToList()
                         })
         .Skip(x)
         .Take(y)
         .ToList();
