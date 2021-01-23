    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<TheNameOfYourModelClass>()
        .Property(p => p.MyColumn)
        .HasConversion(
           v => v ? : 1 : 0,
           v => (v == 1) ? true : false);
    }
