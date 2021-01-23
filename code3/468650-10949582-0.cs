        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(a => a.Roles)
                .WithMany(r => r.Users)
                .Map(config =>
                {
                    config.ToTable("UserRoles");
                    config.MapLeftKey("UserId");
                    config.MapRightKey("RoleId");
                });
        }
