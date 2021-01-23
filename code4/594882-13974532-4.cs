    var criteria = session.CreateCriteria<Mod>();
    var sub = criteria.CreateCriteria("EventList", JoinType.LeftOuterJoin);
        sub.Add(new InExpression("Type", new object[] { 1, 2 }));
    
    var result = criteria.List<Mod>();
