    protected override void OnModelCreating(DbModelBuilder builder)
    {
        builder.Entity<User>()
        .HasMany(u => u.Roles).WithMany(r => r.Users)
        .Map(t => t.MapLeftKey("UserId")
        .MapRightKey("RoleId")
        .ToTable("UserRoles"));
    }
