    public class MyContext : DbContext
    {
        //...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entry>()
                .HasMany(e => e.RelatedEntries)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("Entry_Id");
                    m.MapRightKey("Related_Entry_Id");
                    m.ToTable("EntryRelations");
                });
        }
    }
