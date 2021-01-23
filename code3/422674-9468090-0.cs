    public class ProductCategoryMap : ClassMap<ProductCategory>
    {
        public ProductCategoryMap()
        {
            Id(x => x.Id);
            // Other mappings
            HasMany(x => x.Products).Inverse().Cascade.AllDeleteOrphan();
        }
    }
