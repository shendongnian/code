    var orders = dbContext.Order
        .Select(o => new
        {
            Order = o,
            Items = o.Items.Take(3)
        })
        .AsEnumerable()
        .Select(a => a.Order)
        .ToList();
