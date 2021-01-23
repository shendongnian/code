        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(GetKernel()));
        }
        private IKernel GetKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFoo>().To<Foo>();
            return kernel;
        }
