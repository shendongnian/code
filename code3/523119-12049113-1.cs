    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Comment>()
        .HasRequired(t => t.Post)
        .WithMany(t => t.Comments)
        .Map(m => m.MapKey(new[] { "PostId" }));
    }
