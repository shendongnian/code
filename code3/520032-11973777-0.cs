    var subQuery = DetachedCriteria
        .For<SubNote>("sn")
        .SetProjection(
            Projections.Alias(Projections.Max("Date"), "maxDate"))
        .Add(Restrictions.EqProperty("**sn.COLUMNNAME**", "n.Id"));
        
    var results = CurrentSession.CreateCriteria<Note>("n")
        .Add(Subqueries.Select(subQuery))
        .SetProjection(
            Projections.Alias("n.Id", "Id"))
        .AddOrder(Order.Desc("maxDate")))
        .List<Note>();
