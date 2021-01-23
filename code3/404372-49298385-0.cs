    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         modelBuilder.Entity<First.Entities.Project>().ToTable("Project", "First");
         modelBuilder.Entity<Second.Entities.Project>().ToTable("Project", "Second");
    }
