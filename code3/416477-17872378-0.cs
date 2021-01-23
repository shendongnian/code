    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("Name=DefaultConnection")
        {
        }
        // DbSets ...
    }
