    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {    
       modelBuilder.Entity<Material>()
         .HasMany(a => a.ProductionStepLog)
         .WithMany(a => a.Material)
         .Map(x =>
         {
            x.ToTable("NameOfYourTable");
            x.MapLeftKey("MaterialId");
            x.MapRightKey("ProductionStepLogId");
         });
    }
