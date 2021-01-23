    public class ApplicationContext : DbContext, IDbContext
    {
        public ApplicationContext()
        {
        }
        public ApplicationContext(string databaseName) : base(databaseName)
        {
        }
    }
