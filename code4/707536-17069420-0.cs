                modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(x => {
                    x.ToTable("USER_ROLE_XREF", dbsch);
                    x.MapLeftKey("ID_USER");
                    x.MapRightKey("ID_ROLE");
                });
