    public class Store
    {
        public virtual long StoreId { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
    public class Product
    {
        public virtual long ProductId { get; set; }
        public virtual IList<Store> Stores { get; set; }
    }
    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            HasManyToMany(x => x.Products).Table("StoreProduct")
                                        .ParentKeyColumn("StoreId")
                                        .ChildKeyColumn("RoleId");
        }
    }
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            HasManyToMany(x => x.Stores).Table("StoreProduct")
                                        .Inverse()
                                        .ParentKeyColumn("RoleId")
                                        .ChildKeyColumn("StoreId");
        }
    }
