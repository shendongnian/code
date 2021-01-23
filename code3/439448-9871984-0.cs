    public class ProductRepository<T> : IProductRepository where T: new()
    {
         T _productEntitiesContext;
    
         public productRepository()
         {
             _productEntitiesContext = new T();
         }
    
         public productRepository(T productContext)
         {
             _productEntitiesContext = productContext;
         }
    }
