    var consumersAndPurchases = db.Consumers.Where(...)
        .Select(c => new {
            Consumer = c,
            RelevantPurchases = c.Purchases.Where(...)
        })
        .AsNoTracking()
        .ToList(); // loads in 1 query
    // this should be OK because we did AsNoTracking()
    consumersAndPurchases.ForEach(t => t.Consumer.Purchases = t.RelevantPurchases);
    CannotModify.Process(consumersAndPurchases.Select(t => t.Consumer));
