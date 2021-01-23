    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
             .Entity<Game>()
             .HasRequired(g => g.Player1)
             .WithMany()
             .HasForeignKey(p =>p.Id);
            modelBuilder
             .Entity<Game>()
             .HasRequired(g => g.Player2)
             .WithMany()
             .HasForeignKey(p =>p.Id);
    
            base.OnModelCreating(modelBuilder);
    
        }
