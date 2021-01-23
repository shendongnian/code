    public T SaveOrUpdateCopy(T entity)
    {
        NHibernateSession.Merge(entity);
        return entity;
    }
