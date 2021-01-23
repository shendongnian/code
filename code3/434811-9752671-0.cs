    public class FoodJournalEntities : DbContext
    {
        public DbSet<Journal> Journals { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journal>()
                   .HasOptional(j => j.JournalEntries)
                   .WithMany()
                   .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
