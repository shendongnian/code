    public class ProductRepository : IProductRepority
    {
        private readonly dbConnection;
        public ProductRepository(IDbConnection conn)
        {
            dbConnection = conn;
        }
    }
    public class ProductProcessor
    {
        private readonly productRepository;
        private Product productToProcess;
        public ProductProcessor(IProductRepository productRepo)
        {
            productRepository = productRepo;
        }
        public void Process(Arguments args)
        {
            productToProcess = productRepository.GetById(args.ProductId);
        }
    }
