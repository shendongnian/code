    public class ProductBase
    {
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
    }
    public class CategoryBase
    {
        public string CategoryId { get; set; }
        public virtual ICollection<ProductBase> Products { get; set; }
    }
    public class DerivedProduct : ProductBase
    {
    }
    public class DerivedCategory : CategoryBase
    {
    }
