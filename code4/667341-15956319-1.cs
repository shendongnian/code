    public class MyDBContext : DbContext
    {
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
