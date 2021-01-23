            modelBuilder.Entity<Profile>()
                .Map(m =>
                    {
                        m.ToTable("Profiles");
                        m.MapInheritedProperties();
                    });
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Likes)
                .WithMany()
                .Map(m =>
                    {
                        m.ToTable("PostLikes");
                        m.MapLeftKey("PostId");
                        m.MapRightKey("UserId");
                    });
            modelBuilder.Entity<Profile>()
                .HasMany(p => p.Blogs)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("ProfileBlogs");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("BlogId");
                });
