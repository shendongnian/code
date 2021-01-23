    session.QueryOver<Foo>()
        .Select(Projections.SqlFunction("length", NHibernateUtil.Int32, Projections.Property<Foo>(foo => foo.Name)))
        .List();
    session.CreateCriteria<Foo>()
        .SetProjection(Projections.SqlFunction("length", NHibernateUtil.Int32, Projections.Property(Name)))
        .List<int>();
