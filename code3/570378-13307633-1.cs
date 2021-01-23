    flatList
    .GroupBy(l => new { l.TownId, l.CompanyId })
    .Select(new {
        g => g.Key.TownId
    ,   g => g.Key.CompanyId
    ,   ProductIds = g => g.Select(o => o.ProductId).ToArray()
    ,   Prices = g => g.SelectMany(o => o.Prices).ToArray()
    });
