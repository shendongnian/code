    public class ZoneMedia
    {
        public int ZoneMediaID { get; set; }
        public string MediaName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public virtual ZoneMediaText MediaText { get; set; }
    }
    public class ZoneMediaText
    {
        public int ZoneMediaID { get; set; }
        public string Text { get; set; }
        public int Color { get; set; }
        public virtual ZoneMedia ZoneMedia { get; set; }
    }
    public class TestEFDbContext : DbContext
    {
        public DbSet<ZoneMedia> ZoneMedia { get; set; }
        public DbSet<ZoneMediaText> ZoneMediaText { get; set; }
        protected override void OnModelCreating (DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZoneMedia>()
                .HasOptional(zm => zm.MediaText);
            modelBuilder.Entity<ZoneMediaText>()
                .HasKey(zmt => zmt.ZoneMediaID);
            modelBuilder.Entity<ZoneMediaText>()
                .HasRequired(zmt => zmt.ZoneMedia)
                .WithRequiredDependent(zm => zm.MediaText);
            base.OnModelCreating(modelBuilder);
        }
    }
    class Program
    {
        static void Main (string[] args)
        {
            var dbcontext = new TestEFDbContext();
            var medias = dbcontext.ZoneMedia.ToList();
        }
    }
