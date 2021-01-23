    public class MyDataContext : DbContext {
        public MyDataContext() : base("MyDatabaseName") 
        {
            Database.DefaultConnectionFactory = new SqlConnectionFactory(myConnectionString);
        }
    }
