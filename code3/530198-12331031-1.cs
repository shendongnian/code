    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => RelatedProducts)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("ProductID");
                    m.MapRightKey("RelatedID");
                    m.ToTable("product_related");
                });
        }
    }
