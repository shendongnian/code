    public IEnumerable<T> SearchQuery(this IDbSet<T> set, string query)
    {
        var dbSet = set as DbSet<T>;
        if (dbSet != null)
        {
            return dbSet.SqlQuery(query);
        }
        else 
        {
            throw new NotSupportedException();
        }
    }
