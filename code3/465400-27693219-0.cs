    public static class DbContextExtensions
    {
        public static void SetCommandTimeout(this DbContext dbContext,
            int TimeOut)
        {
            ((IObjectContextAdapter)dbContext).ObjectContext.CommandTimeout = TimeOut;
        }
    }
