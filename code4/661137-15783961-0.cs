    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {    
       modelBuilder.Entity<Material>()
         .HasMany(a => a.ProductionStepLog)
         .WithMany(a => a.Material)
         .Map(x =>
         {
            a.ToTable("NameOfYourTable");
            a.MapLeftKey("MaterialId ");
            a.MapRightKey("ProductionStepLogId");
         });
    }
