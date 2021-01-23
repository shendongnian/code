    public class Search : ISearch
    {
        public Products GetProductList()
        {
            return new Products(new ProductDA().GetProducts());
        }
    }
