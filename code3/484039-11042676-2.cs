    using MySqlExmpleDll;
    ...
    class ProductService
    {
        private IProductData _productData;
        public ProductService(IProductData productData)
        {
            _productData = productData;
        }
        public IList<Product> GetAllProductsIn(int categoryId)
        {
            IList<Product> products;
            products = _productData.GetAllProducts();
            
            return products;
        }
    }
