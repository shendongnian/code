    [CollectionDataContract]
    public class Products : List<Product> 
    {
        public Products(IEnumerable<Product> products) : base(products) { }
    }
