    using (ISession session = NHibernateHelper.OpenSession())
    {
        var rowCount = session.CreateCriteria<PSScript>()
                            .SetProjection(Projections.RowCount())
                            .UniqueResult<Int32>();
        var results = session.CreateCriteria<PSScript>()
            .SetFirstResult((pageIndex - 1) * pageSize)
            .SetMaxResults(pageSize)
            .ToList<PSScript>();
        return new PagedList<PSScript>(results, pageSize, pageSize, rowCount);
    }
