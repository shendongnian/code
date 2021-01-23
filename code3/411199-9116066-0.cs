    public class Config
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string ConfigField1 { get; set; }
        public string ConfigField2 { get; set; }
    }
    
    public class ProductMap : ClassMap<Product>
    {
        public class ProductMap()
        {
            HasOne(p => p.Config);
        }
    }
    public class ConfigMap : ClassMap<Config>
    {
        public class ConfigMap()
        {
            Id(c => c.Id, "ProductId").GeneratedBy.Foreign("Product");
            References(c => c.Product, "ProductId");
            Map(c => ...);
        }
    }
