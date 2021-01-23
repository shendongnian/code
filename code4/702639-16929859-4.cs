    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        { 
            // note how I am specifying it here as 4 digits after the decimal point
            // and for the second one, 3 digits
            // this is where EF precision must be configured so you can expect
            // the values you tell EF to save to the db
            context.Products.Add(new Product() {Id = 1, Fineness = 145.2442m});
            context.Products.Add(new Product() {Id = 2, Fineness = 12.341m});
        }
    }
    public class Context : DbContext
    {
        public IDbSet<Product> Products { get; set; }
        public Context()
        {
            // I always explicitly define how my EF should run, but this is not needed for the answer I am providing you
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // so here, I am override the model configuration which is what 
            // EF can use in order to set-up the behaviour of how everything 
            // is configured in the database, from associations between
            // multiple entities and property validation, Null-able, Precision, required fields etc
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");
            HasKey(x => x.Id).Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // HAS PRECISION. 
            // Enforces how the value is to be stored in the database
            // Here you can see I set a scale of 3, that's 3 digits after
            // the decimal. Notice how in my seed method, I gave a product 4 digits!
            // That means it will NOT save the product with the other trailing digits.
            Property(x => x.Fineness).HasPrecision(precision: 10, scale: 3);
        }
    }
