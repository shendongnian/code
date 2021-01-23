    [DbConfigurationType(typeof(DbContextConfiguration))]
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            ...
        }
        public DbSet<...> ...{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ...
        }
    }
