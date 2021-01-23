    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Comment>()
        .HasRequired(t => t.Post)
        .WithMany(t => t.Comments)
        .Map(d => d.MapKey(new[] { "PostId" }));
    }
