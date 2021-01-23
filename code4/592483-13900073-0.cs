    var projections = Projections.ProjectionList();
    projections
      .Add(Projections.Property("EntityId"))
      .Add(Projections.Property("Code"))
      .Add(Projections.Constant(0), "ID"); // const projection
                    
    var list = session
      .CreateCriteria<MyEntity>()
      .SetProjection(projections) // projections
      .SetResultTransformer(new AliasToBeanResultTransformer(typeof(MyEntity)))
      .List<MyEntity>();
