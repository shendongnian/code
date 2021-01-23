    session.CreateCriteria<Person>()
        .SetProjection(Projections.Min("ID"))
        .Add(Subqueries.PropertyIn("ID", 
                 DetachedCriteria.For<Person>()
                      .Add(Restrictions.Eq("CITY", "SYDNEY")) 
                      .SetProjection(Projections.Property("Id"))
                      .SetMaxResults(1000)))
        .List();
