    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      var members = modelBuilder.Entity<Members>();
      members.HasRequired(m => m.Recruiter)
             .WithMany()
             .HasForeignKey(m => m.RecruiterID);
      members.HasRequired(m => m.Auditor)
             .WithMany()
             .HasForegnKey(m => m.AuditorID);
    }
