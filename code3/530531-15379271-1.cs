    public class ProductProcessor
    {
        private readonly IProductRepositoryFactory productRepositoryFactory;
        public ProductProcessor(IProductRepositoryFactory productRepositoryFactory)
        {
            this.productRepositoryFactory = productRepositoryFactory;
        }
        public void Process(Arguments arguments)
        {
            Product productToProcess;
            var productRepository =
                this.productRepositoryFactory.Create(arguments.ConnectionString);
            if (!string.IsNullOrEmpty(arguments.ProductName))
            {
                productToProcess = productRepository.GetByName(arguments.ProductName);
            }
            else
            {
                productToProcess = productRepository.GetById(arguments.ProductId);
            }
            // ....
        }
    }
