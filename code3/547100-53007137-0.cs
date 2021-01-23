    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().Property<string>("TenantId").HasField("_tenantId");
    
        // Configure entity filters
        modelBuilder.Entity<Blog>().HasQueryFilter(b => EF.Property<string>(b, "TenantId") == _tenantId);
        modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
    }
