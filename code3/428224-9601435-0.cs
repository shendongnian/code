    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name).Nullable();
            ...
        }
    }
