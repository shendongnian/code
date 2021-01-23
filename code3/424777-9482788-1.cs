    // initialize the vehicles
    session.Query<PlannedSalesInYear>()
        .Fetch(ps => ps.Vehicle)
        .AsEnumerable()
        .GroupBy(a => a.Vehicle)
        .ToDictionary(
            gr => gr.Key,
            gr => (IDictionary<int, int>)gr.ToDictionary(a => a.Year, a => a.PlannedSales));
