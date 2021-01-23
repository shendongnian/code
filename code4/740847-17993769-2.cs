    public class ProductDataServiceProvider
    {
         private IProductsRepository _productRepository;
         private IStockGateway _stockGateway;
         // inject implementations
         public ProductDataServiceProvider(
             IProductRepository productRepository,
             IStockGateway stockGateway)
         {
             _productRepository = productRepository;
             _stockGateway = stockGateway; 
         }
         
         public void ProcessProductFeed()
         {
              // use repository and gateway
         }
    }
