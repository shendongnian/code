    var projections = Projections.ProjectionList()
            .Add(Projections.Id())
            .Add(Projections.Property("MsgNumber"))
            .Add(hasAccess ? Projections.Property("Title") : Projections.Constant("*********"));
    var criteria = session.CreateCriteria<Message>()
            .Add(... your restrictions ...)
            .SetProjection(projections)
            .List<object[]>();
