    public class MyDataContext : DbContext
    {
        public DbSet<Bundle> Bundle { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Siteconfig> Siteconfig { get; set; }
    }
