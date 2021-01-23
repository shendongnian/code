    public class ProductResultEventArgs : EventArgs
    {
        public ProductResultEventArgs(List<Product> products)
        {
            Products = products;
        }
        public List<Product> Products { get; private set; }
    }
