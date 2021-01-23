        protected override void OnModelCreating(DbModelBuilder mb)
        {
            base.OnModelCreating(mb);
            mb.Entity<Job>()
                .HasKey(i => i.uuid);
            mb.Entity<Job>()
              .Property(i => i.uuid)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
              .HasColumnName("CustomIdName");
        }
