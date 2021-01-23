    public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
    {
        var query = _session.Query<TEntity>();
        return query.Where(expression);
    }
