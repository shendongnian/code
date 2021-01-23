    public class DbContext2 : DbContext
    {
        public DbContext2(string connectionString)  : base (connectionString)
        {
        }
         
        public DbSet<Table1> Object5 { get; set; }
    }
