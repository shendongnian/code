    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("YourDbFileName")
        {
        }
        // DbSets ...
    }
