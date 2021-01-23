    var linq2ObjectsSource = new List<DateTime?>() { null }.AsQueryable();
    var visitedSource = new VisitedQueryable<DateTime?, EntityFunctionsFakerVisitor>(linq2ObjectsSource);
    var visitedQuery = visitedSource.Select(dt => EntityFunctions.AddDays(dt, 1));
    var results = visitedQuery.ToList();
    Assert.AreEqual(1, results.Count);
    Assert.AreEqual(null, results[0]);
