    public class Product
    {
        ...
        public List<ProductProperty> AdditionalProperties { get; set; }
    }
    
    class ProductProperty
    {
        public string Name { get; set; }
        public object Data { get; set; }
    }
