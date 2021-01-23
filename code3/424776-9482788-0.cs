    // get the results
    IDictionary<Vehicle, IDictionary<int, int>> results = session.Query<PlannedSalesInYear>()
        .Select(ps => new { VehicleId = ps.Vehicle.Id, ps.Year, ps.PlannedSales })
        .AsEnumerable()
        .GroupBy(a => a.VehicleId)
        .ToDictionary(
            gr => session.Load<Vehicle>(gr.Key),
            gr => (IDictionary<int, int>)gr.ToDictionary(a => a.Year, a => a.PlannedSales));
    // initialize the vehicles
    session.QueryOver<Vehicle>().WhereRestrictionOn(v => v.Id).IsIn(results.Keys.Select(v => v.Id).ToArray()).List();
