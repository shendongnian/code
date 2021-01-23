    var query =
        from c in collection.AsQueryable<C>()
        where c.A.ContainsAny(new[] { 1, 2, 3 })
        select c;
    // or
    var query =
        collection.AsQueryable<C>()
        .Where(c => c.A.ContainsAny(new[] { 1, 2, 3 }));
