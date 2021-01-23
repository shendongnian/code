    public static IQueryable<T> FrontEnd<T>(this DbSet<T> dbSet)
        where T : class, IPublishable
    {
        return dbSet.Where(x => x.IsPublished);
    }
