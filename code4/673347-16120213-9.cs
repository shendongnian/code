    modelBuilder.Entity<UserSystemRole>()
        .HasKey(usr => new { usr.UserId, usr.SystemId, usr.RoleId });
    
    modelBuilder.Entity<UserSystemRole>()
        .HasRequired(usr => usr.User)
        .WithMany(u => u.UserSystemRoles)
        .HasForeignKey(usr => usr.UserId);
    modelBuilder.Entity<UserSystemRole>()
        .HasRequired(usr => usr.System)
        .WithMany(s => s.UserSystemRoles)
        .HasForeignKey(usr => usr.SystemId);
    modelBuilder.Entity<UserSystemRole>()
        .HasRequired(usr => usr.Role)
        .WithMany(r => r.UserSystemRoles)
        .HasForeignKey(usr => usr.RoleId);
