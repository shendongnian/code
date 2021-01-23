    session.CreateCriteria<Entity1>()
    	.CreateCriteria("Prop3", "prop3", JoinType.InnerJoin)
    	.Add(Restrictions.Eq(Projections.Property("Prop2"), "Criteria!"))
    	.Future<Entity1>();
    				
    session.CreateCriteria<Entity1>()
    	.Add(Restrictions.Eq(Projections.Property("Prop2"), "Criteria!"))
    	.SetFetchMode("Prop2", FetchMode.Join)
    	.Future<Entity1>();
    				
    var query = session.CreateCriteria<Entity1>()
    	.Add(Restrictions.Eq(Projections.Property("Prop2"), "Criteria!"))
    	.SetFetchMode("Prop4", FetchMode.Join)
    	.Future<Entity1>();
    
    var clients = query.ToList();
