    // Build the parameter to the where clause predicate and access AwesomeProperty
    var regionParameter = Expression.Parameter(typeof(Region), "region");
    var awesomeProperty = Expression.Property(regionParameter, "AwesomeProperty");
    // Build the where clause predicate using the AwesomeProperty access
    var predicate = Expression.Lambda<Func<Region, bool>>(awesomeProperty);
    // Get the table, which serves as the base query
    var table = dc.Regions.AsQueryable();
    // Call the Where method using the predicate and the table as the base query
    var whereCall = Expression.Call(
        typeof(Queryable),
        "Where",
        new[] { table.ElementType },
        table.Expression,
        predicate);
    // Get an IQueryable<Region> which executes the where call on the table
    var query = table.Provider.CreateQuery<Region>(whereCall);
    var results = query.ToList();
