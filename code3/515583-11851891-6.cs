    public class Gallery
    {
        public int GalleryId { get; set; }
        public virtual Painting Cover { get; set; }
        public virtual Painting Slider { get; set; }
    }
    public class Painting
    {
        public int PaintingId { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Painting> Paintins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gallery>().HasOptional(g => g.Cover).WithMany().Map(m => m.MapKey("CoverPaintingId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<Gallery>().HasOptional(g => g.Slider).WithMany().Map(m => m.MapKey("SliderPaintingId")).WillCascadeOnDelete(false);
        }
    }
