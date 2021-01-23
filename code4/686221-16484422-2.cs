    public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter != null)
        {
            query = query.Where(filter);
        }
    }
