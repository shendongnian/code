        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>().Property(x => x.ResultId)
                   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
