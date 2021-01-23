    var conditionalOrderBy = Projections.Conditional
    (
        Restrictions.IsNull("CommonName") // or LastName, not sure from a question snippet
      , Projections.Property("FirstName")
      , Projections.Property("CommonName") // or LastName
    );
    
    var list = criteria.GetExecutableCriteria(session)  
      .AddOrder(new Order(conditionalOrderBy, true))
      .List<Person>()
    ;
