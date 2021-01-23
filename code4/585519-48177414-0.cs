    modelBuilder.Entity<User>()
        .HasMany(usr => usr.Roles)
        .WithMany(role => role.Users)
        .Map(m => {
            m.ToTable("UsersRoles");
            m.MapLeftKey("UserId");
            m.MapRightKey("RoleId");
        })
        .WillCascadeOnDelete(false);
