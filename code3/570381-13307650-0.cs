    flatList.GroupBy(l => new { l.TownId, l.CompanyId })
            .Select(g => new 
            {
                TownId = g.Key.TownId,
                CompanyId = g.Key.CompanyId,   
                Products = g.Select(o => o.ProductId).ToArray(),
                Prices = g.SelectMany(o => o.Prices).ToArray()
            });
