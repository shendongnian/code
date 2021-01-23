    public IQueryable<TEntity> GetQuery<TEntity>() 
        where TEntity : class, ISiteDependent
    {
         return from query in DbContext.Set<TEntity>()
                join site in DbContext.Set<Site>() 
                     on query.SiteID equals site.SiteID // SiteID is available now
                select query;
    }
