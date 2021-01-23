    private static IUnityContainer BuildUnityContainer()
        {
          var container = new UnityContainer();
    
          // register all your components with the container here
          // it is NOT necessary to register your controllers
    
          // e.g. container.RegisterType<ITestService, TestService>();    
          //RegisterTypes(container);
          container = new UnityContainer();
          container.RegisterType<IProductRepository, ProductRepository>();
       
    
          MvcUnityContainer.Container = container;
          return container;
        }
