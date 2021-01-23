    public class MyDbContext : DbContext
        {
            public DbSet<Customer> Customer { get; set; }
            public MyDbContext()
            {
            }
        }
