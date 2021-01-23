    protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
    {
        modelBuilder.Entity()
            .HasMany(u => u.ProjectAuthorizations)
            .WithRequired(a => a.UserProfile)
            .WillCascadeOnDelete(true);
    }
