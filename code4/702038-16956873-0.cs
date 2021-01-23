    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.ImageUrl);
            HasManyToMany(x => x.ManyProduct)
                .ParentKeyColumn("product1_id")
                .ChildKeyColumn("product2_id")
                .Cascade.All()
                .Table("ProductInProduct");
        }
    }
