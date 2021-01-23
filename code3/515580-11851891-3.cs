    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gallery>().HasRequired(g => g.Cover).WithMany().WillCascadeOnDelete(false);
        modelBuilder.Entity<Gallery>().HasRequired(g => g.Slider).WithMany().WillCascadeOnDelete(false);
    }
