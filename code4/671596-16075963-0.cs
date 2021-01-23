    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<User>()
                    .HasMany<Sites>(u => u.Sites)
                    .WithMany(e => e.Users)
                    .Map(
                        m =>
                            {
                                m.MapLeftKey("User_Id");
                                m.MapRightKey("Site_Id");
                                m.ToTable("UserSites");
                            });
    
        //for prevent error 'The referential relationship will result in a cyclical reference that is not allowed'
        modelBuilder.Entity<Sites>()
                    .HasRequired(s => s.User)
                    .WithMany()
                    .WillCascadeOnDelete(false);
    }
