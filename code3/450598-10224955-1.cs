    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
               
                modelBuilder.Entity<Song>()
                    .HasMany(s => s.Albums)
                    .WithMany(a => a.Songs)
                    .Map(m =>
                    {
                        m.MapLeftKey("SongID");
                        m.MapRightKey("AlbumID");
                        m.ToTable("SongAlbums");
                    });
            }
