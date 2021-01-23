        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Gallery>()
                .HasMany(p => p.Images)
                .WithMany(p => p.Galleries)
                .Map(c =>
                {
                    c.MapLeftKey("Gallery_Id");
                    c.MapRightKey("Image_Id");
                    c.ToTable("GalleryImages");
                });
            modelBuilder
                .Entity<User>()
                .HasMany(p => p.Lightboxes)
                .WithMany(p => p.Users)
                .Map(c =>
                {
                    c.MapLeftKey("User_Id");
                    c.MapRightKey("Lightbox_Id");
                    c.ToTable("UserLightboxes");
                });
            modelBuilder
                .Entity<Image>()
                .HasMany(p => p.Lightboxes)
                .WithMany(p => p.Images)
                .Map(c =>
                {
                    c.MapLeftKey("Image_Id");
                    c.MapRightKey("Lightbox_Id");
                    c.ToTable("ImageLightboxes");
                });
        }
