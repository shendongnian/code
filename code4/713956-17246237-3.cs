    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {    
        modelBuilder.Entity<Object>()
            .HasMany(x => x.Users )
            .WithMany(x => x.Objects)
        .Map(x =>
        {
            x.ToTable("UserObjects"); 
            x.MapLeftKey("ObjectID");
            x.MapRightKey("UserID");
        });
    }
