    var sub = DetachedCriteria
     .For<Event>()
     .Add(Restrictions.In("Type", new int[] {1, 2 })) // WHERE
     .SetProjection(Projections.Property("ModId")); // Mod.ID the SELECT clause
    
    var criteria = session.CreateCriteria<Mod>();
    criteria.Add(Subqueries.PropertyIn("ID", sub)); // Mod.ID in (select
    var result = criteria.List<Mod>();
