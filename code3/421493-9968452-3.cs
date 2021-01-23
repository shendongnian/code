    public class MainTable
    {
        public int ThePrimaryKeyId { get; set; }
        public string Name { get; set; }
    }
    public class ExtendedTable
    {
        public int NotTheSameNameID { get; set; }
        public string AnotherTableColumn { get; set; }
        public MainTable MainEntry { get; set; }
    }
    public class MainDbContext : DbContext
    {
        public DbSet<MainTable> MainEntries { get; set; }
        public DbSet<ExtendedTable> ExtendedEntries { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainTable>()
                .HasKey(x => new { x.ThePrimaryKeyId });
            modelBuilder.Entity<ExtendedTable>()
                .HasKey(x => new { x.NotTheSameNameID });
            // Extended To Main 1 on 1
            modelBuilder.Entity<ExtendedTable>()
                .HasRequired(i => i.MainEntry)
                .WithRequiredDependent();
        }
    }
