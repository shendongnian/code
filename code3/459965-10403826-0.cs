    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Message>().Property(x => x.Subject).IsRequired();
      base.OnModelCreating(modelBuilder);
    }
