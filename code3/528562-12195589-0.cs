    public class ConnectionContext : DbContext
    {
        public ConnectionContext() 
            : base("nameOrConnectionString")
        {
            if (!this.Database.Exists())
                throw new Exception("Database does not exist");
        }
    
        public DbSet<Table1> Table1 { get; set; }
    }
