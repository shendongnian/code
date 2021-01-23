     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
        modelBuilder.Entity<Product>().Property(u => u.Price.Amount)
                                           .HasColumnName("Amount");
     }
