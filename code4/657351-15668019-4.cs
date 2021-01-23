    public class DataContext : DbContext
    {
        public DataContext(DbConnection existingConnection)
            : base(existingConnection, true) { }
    }
