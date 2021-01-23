    public bool Contains(TId id)
    {
        using (var session = NHibernateHelper.OpenSession())
        { 
            return session.CreateCriteria(typeof(TEntity))
                .Add(Expression.Eq("id", id))
                .SetProjection( Projections.Count("id"))
                .UniqueResult() > 0
        }
    }
