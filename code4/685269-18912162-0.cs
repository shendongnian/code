    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Subject>().
            HasMany(m => m.Prerequisites).
            WithMany()
            .Map(m =>
                {
                    m.ToTable("SubjectPrerequisite");
                    m.MapLeftKey("SubjectId");
                    m.MapRightKey("PrerequisiteId");
                });
    }
