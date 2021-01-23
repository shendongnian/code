    public class ProductDBContext : DbContext
    {
        public ProductDBContext ()
            : base("MyConnection") //web.config
        {
        }
        public DbSet<Product> Products { get; set; }
    }
    
    // Your View:
    // CREATE VIEW dbo.Product
    // AS
    // SELECT dbo.ProductProfile.ID, dbo.ProductProfile.ProductCode, dbo.ProductTitle.ProfileID, dbo.ProductTitle.ProductTitle 
    // FROM   dbo.ProductProfile INNER JOIN
    //          dbo.ProductTitle ON dbo.ProductProfile.ID = dbo.ProductTitle.ProfileID
    //
    [Table("dbo.Product")]  
    public class Product
    {
        [Key]
        public long ID { get; set; }
        [Display(Name = "Product Code")]
        public int ProductCode { get; set; }
        [Display(Name = "Product Title")]
        public string ProductTitle { get; set; }
    }
