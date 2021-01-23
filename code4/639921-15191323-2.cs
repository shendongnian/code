    public interface IProductRepo
    {
        List<Product> GetProducts();
        Product GetProduct(int Id);
        void DeleteProduct(int Id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
    }
    public class ProductRepo : IProductRepo
    {
        public ProductRepo(ISession session)
        {
             _session = session;  
        }
        public Product GetProduct(int Id)
        {
             return _session<Product>().Get(Id);
        }
         
        //Implementation of other methods of IProductRepo
        
         ISession _session;
    }
