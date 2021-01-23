    public static void Clear<T>(this DbSet<T> dbSet)
    {
        dbSet.RemoveRange(dbSet)
    }
 
