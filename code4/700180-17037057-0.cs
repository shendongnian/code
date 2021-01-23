    var results = session.CreateCriteria<DrMaster>()
        .Add(Expression.EqProperty("fDate",
            Projections.Conditional(Expression.Eq("Date", null), 
                Projections.SubQuery(DetachedCriteria.For<DrMaster>()
                    .Add(Expression.EqProperty("fPropertyId", "PropertyId"))
                    .SetProjection(Projections.Max("fDate"))),
                Projections.Property("Date"))))
        .Add(Expression.EqProperty("fPropertyId", "PropertyId"))
        .List<DrMaster>();
