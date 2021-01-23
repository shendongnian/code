    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
             .Entity<Game>()
             .HasRequired(g => g.Player1)
             .WithMany()
             .WillCascadeOnDelete(false);
            modelBuilder
             .Entity<Game>()
             .HasRequired(g => g.Player2)
             .WithMany()
             .WillCascadeOnDelete(false);
    
            base.OnModelCreating(modelBuilder);
    
        }
