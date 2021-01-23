    var query =
        from c in session.Query<Customer>()
        from o in c.Orders
        where o.IsCanceled
        select new { Customer = c, Order = o }
    var results = query.AsEnumerable()
        .ToLookup(a => a.Customer, a => a.Order);
