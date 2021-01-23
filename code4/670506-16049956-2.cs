    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
              .HasMany<SocialProvider>(r => r.SocialContacts)
              .WithMany(u => u.Contacts)
              .Map(m =>
              {
                  m.ToTable("UsersInSocialContacts");
                  m.MapLeftKey("UserId");
                  m.MapRightKey("ProviderId");//If not ProviderId  try Id
              });
        }
