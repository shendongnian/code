        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assessor>()
                .HasMany(a => a.Documents)
                .WithMany(d => d.Assessors)
                .Map(m =>
                    {
                        m.MapLeftKey("AssessorID");
                        m.MapRightKey("DocumentID");
                        m.ToTable("AssessorDocuments");
                    });
            base.OnModelCreating(modelBuilder);
        }
