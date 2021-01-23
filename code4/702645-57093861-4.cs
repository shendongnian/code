    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(x => x.Fineness).HasPrecision(10, 3);
    
        base.OnModelCreating(modelBuilder);
    }
