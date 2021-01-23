      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithMany(b => b.Authors)
                .Map(m =>
                    {
                        m.ToTable("AuthorBooks");
                        m.MapLeftKey("AuthorId");
                        m.MapRightKey("BookId");
                    });
    }
