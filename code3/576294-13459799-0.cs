    // Factory
         public class ServiceFactory : IServiceFactory
            {
             public IProductService GetProductService()
                {
                    return new ProductService();
                }
             public IPeopleService GetPeopleService ()
                {
                    return new PeopleService ();
                }
              }
    
    // Repository
        public class ProductRepository
            {
            public void DoSomething()
            {
                // use dependecy injection to avoid this tight coupling
                var factory = new ServiceFactory(); 
                var service = factory.GetProductService();
                service.DoMyStuff();
            }
    
    }
