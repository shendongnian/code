    public partial class Order
    {
        public IEnumerable<Product> Products
        {
            get
            {
                return OrderProducts.Select(op => op.Product);
            }
        }
    }
