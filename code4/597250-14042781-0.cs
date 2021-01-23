    var instrumentCriteria = DetachedCriteria.For<Instrument>()
        // I. Financial as a reference
        .SetProjection(Projections.Property("Financial.ID")) 
        // II. or just a int property FinancialId
        // .SetProjection(Projections.Property("FinancialId")) 
        .Add(Restrictions.In("Agency.ID", new object[] { 2, 3 })); // Where
    
    var financialCriteria = DetachedCriteria.For<Financial>()
        .SetProjection(Projections.Property("ID")) // the ID of instrument
        .Add(Subqueries.PropertyIn("ID", instrumentCriteria));
    
    var queryCriteria = session.CreateCriteria<Permit>()
        .Add(Subqueries.PropertyIn("Financial.ID", financialCriteria));
    
    var result = queryCriteria.List<Permit>();
    Assert.IsTrue(result.Any());
