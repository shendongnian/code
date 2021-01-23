    public class Db : DbContext {
        private static SqlCeConnectionFactory factory = 
                   new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
        public static Db Create(string filename) {
            return new Db(factory.CreateConnection(@"Data Source=" + filename));
        }
        public Db(DbConnection conn)
            : base(conn, true) {
        }
        public DbSet<object> TableName {get; set;}
    }
