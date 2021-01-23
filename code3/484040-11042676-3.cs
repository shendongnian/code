    namespace ProductExampleInterfaces
    {
        public interface IProductData
        {
            IList<Product> GetAllProducts();
            string GetProductName(int id);
            ...
        }
        ...
    }
