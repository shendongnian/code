    public class Details
    {
        public string Name;
        public string Zip;
        public string Email;
    }
    public class DetailsKeyValue
    {
        public string FieldLabel { get; set; }
        public string FieldValue { get; set; }
    }
    public class DetailsKeyValueContext: DbContext
    {
        public DbSet<DetailsKeyValue> DetailsKeyValue { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailsKeyValue>()
                .HasKey(x => x.FieldLabel);
        }
    }
