    modelBuilder.Entity<User>()
                .HasMany(a => a.Events)
                .WithMany(b=> b.Guests)
                .Map(x =>
                {
                    x.MapLeftKey("UserId");
                    x.MapRightKey("EventId");
                    x.ToTable("EventGuests");
                });
