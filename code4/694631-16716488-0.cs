    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Either entirely
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        // or for one model object
        modelBuilder.Entity<Person>()
           .HasRequired(p => p.Department)
           .WithMany()
           .HasForeignKey(p => p.DepartmentId)
           .WillCascadeOnDelete(false);
    }
