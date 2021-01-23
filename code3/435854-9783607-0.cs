    public static IQueryable<T> YourHugeQueryMethod(DbContext context, ...) 
         where T : IView, class, new()
    {
        DbSet<T> set = context.Set<T>();
        return set.Where(...);
    }
