      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
           modelBuilder.Entity<User>().ToTable("aspnet_users");
           modelBuilder.Entity<Role>().ToTable("aspnet_roles");
           modelBuilder.Entity<User>()
           .HasMany(u => u.Roles).WithMany(r => r.Users)
                .Map(m =>
                {
                    m.ToTable("aspnet_UsersInRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
       }
