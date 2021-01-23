    public class Product
    {
        public virtual int ID { get; set; }
        public virtual string StoreBrand { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string Description { get; set; }
    
        public virtual IEnumerable<ProductVariation> Variations { get; set; }
        public override Equals(object obj)
        {
            return Equals(obj as Product)
        }
        public override Equals(Product other)
        {
            return (other != null) && (Id == other.Id) && (StoreBrand == other.StoreBrand);
        }
        public override GetHashCode()
        {
            unchecked
            {
                return Id.GetHashCode() * 397 + StoreBrand.GetHashCode();
            }
        }
    }
    
    public class ProductVariation
    {
        public virtual int ID { get; set; }
        public virtual Product Product {get; set;}      
    
        public virtual string Size { get; set; }
        public virtual double Price { get; set; }
    }
    public class ProductMapper : ClassMap<Product>
    {
        public ProductMapper()
        {
            // Id alone is not unique, hence compositeId
            CompositeId()
                .KeyProperty(x => x.ID)
                .KeyProperty(x => x.StoreBrand);
            Map(x => x.ProductName);
            Map(x => x.Description);
    
            HasMany(x => x.Variations)
                .KeyColumn("ProductID", "StoreBrand");
        }
    }
    public class ProductVariationMapper : ClassMap<ProductVariation>
    {
        public ProductVariation()
        {
            Id(x => x.ID);
            Map(x => x.Size);
            Map(x => x.Price);
    
            References(x => x.Product)
                .Column("ProductID", "StoreBrand");
        }
    }
