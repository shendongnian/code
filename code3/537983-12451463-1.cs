    public class DbContextFactory : IDbContextFactory
    {
    
        #region Implementation of IDbContextFactory
    
        public T CreateDbContext<T>() where T : DbContext, new()
        {
            // Create a new instance of T and return.
            return new T();
        }
    
        #endregion
    }
