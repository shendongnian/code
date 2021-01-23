    public MyContext : DbContext
    {
        public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<MyCoolEntity> MyCoolEntities { get; set; }
        /* ... */
    }
