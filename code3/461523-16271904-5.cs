  protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .Property(t => t.GameTime )
            .HasColumnType("datetime2");
    }
