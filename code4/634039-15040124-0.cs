    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>().Property(a => a.Latitude).HasPrecision(18, 9);
        modelBuilder.Entity<Activity>().Property(a => a.Longitude).HasPrecision(18, 9);
    }
