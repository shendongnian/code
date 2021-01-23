    public MyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<AnotherClass> AnotherClasses { get; set; }
    }
