    public class Gallery
    {
        public int GalleryId { get; set; }
        [ForeignKey("CoverPaintingId")]
        public virtual Painting Cover { get; set; }
        public int? CoverPaintingId { get; set; }
        [ForeignKey("SliderPaintingId")]
        public virtual Painting Slider { get; set; }
        public int? SliderPaintingId { get; set; }
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
            modelBuilder.Entity<Gallery>().HasOptional(g => g.Cover).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Gallery>().HasOptional(g => g.Slider).WithMany().WillCascadeOnDelete(false);
        }
    }
