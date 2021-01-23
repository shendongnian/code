    public static class UnityConfig
        {
            public static void RegisterComponents()
            {
    			var container = new UnityContainer();
                
                // register all your components with the container here
                // it is NOT necessary to register your controllers
                
                **container.RegisterType<IEmployee,EmployeeManager>();**
    //this could be your interface and the class implementing the interface.
                
                DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            }
        }
