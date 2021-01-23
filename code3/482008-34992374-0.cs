        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            **container.RegisterType<IEmployee,EmployeeManager>();**
