    public static class UnityConfig
        {
            public static void RegisterComponents()
            {
    			var container = new UnityContainer();
                // **** Important note -----
                // register all your components with the container here
                // e.g. container.RegisterType<ITestService, TestService>();
    
               
                DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
             
                GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            }
        }
