    var results = _dbContext.GroupBy( i => new { i.ItemName, i.ItemTypeName })
        .Select( g => new Item()
            {
                ItemName = g.Key.ItemName,
                ItemTypeName = g.Key.ItemTypeName,
                Prices = g.Select( p => new Price(){Price = p.Price})
             });
