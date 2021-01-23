    flatList
    .GroupBy(l => new { l.TownId, l.CompanyId })
    .Select(g => new {
        g.Key.TownId
    ,   g.Key.CompanyId
    ,   ProductIds = g.Select(o => o.ProductId).ToArray()
    ,   Prices = g.SelectMany(o => o.Prices).ToArray()
    });
