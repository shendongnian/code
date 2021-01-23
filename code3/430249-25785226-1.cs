    protected override void OnModelCreating(DbModelBuilder modelBuilder)       
    {
        modelBuilder.Entity<EntityClass>().HasKey(p => p.Id);
        
        modelBuilder.Entity<EntityClass>()
            .Property(c => c.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        
        base.OnModelCreating(modelBuilder);   
    }
