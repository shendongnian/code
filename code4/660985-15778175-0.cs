    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    
      modelBuilder.Entity<Annoucement>()
        .HasMany(x => x.Files)
        .WithMany(x => x.Announcements)
        .Map(x => { 
          x.ToTable("AnnouncementFiles"; 
          x.MapLeftKey("AnnouncementID"); 
          x.MapRightKey("FileID"); 
        });
    }
