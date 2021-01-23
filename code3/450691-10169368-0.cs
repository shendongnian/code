    var blogs = s.CreateCriteria<Invoice>()
      .SetMaxResults(30)
      .Future<Invoice>();
    var countOfInvoices = s.CreateCriteria<Invoice>()
      .SetProjection(Projections.Count(Projections.Id()))
      .FutureValue<int>();
