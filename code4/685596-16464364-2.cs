    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasRequired(a => a.Manager)
            .WithMany()
            .HasForeignKey(a => a.EmployeeId);
    }
