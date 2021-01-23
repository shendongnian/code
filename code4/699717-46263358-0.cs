    public static class DbSetExtensions
    {
        public static TEntity FirstOrCreate<TEntity>(
                this DbSet<TEntity> dbSet,
                Expression<Func<TEntity, bool>> predicate,
                Func<TEntity> defaultValue)
            where TEntity : class
        {
            var result = predicate != null
                ? dbSet.FirstOrDefault(predicate)
                : dbSet.FirstOrDefault();
    
            if (result == null)
            {
                result = defaultValue?.Invoke();
                if (result != null)
                    dbSet.Add(result);
            }
    
            return result;
        }
            
        public static TEntity FirstOrCreate<TEntity>(
                this DbSet<TEntity> dbSet,
                Func<TEntity> defaultValue)
            where TEntity : class
        {
            return dbSet.FirstOrCreate(null, defaultValue);
        }
    
    }
