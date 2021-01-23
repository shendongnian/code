    public IQueryable<TEntity> GetQuery<TEntity>() 
        where TEntity : IFoo
    {
         return from query in DbContext.Set<TEntity>()
                join site in DbContext.Set<Site>() 
                     on query.SiteID equals Site.SiteID
                select query;
    }
