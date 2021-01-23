        private static void RegisterServices(IKernel kernel)
        {
            kernel.BindSharpRepository();
            RepositoryDependencyResolver.SetDependencyResolver(
                new NinjectDependencyResolver(kernel)
            );
            string connectionString = ConfigurationManager.ConnectionStrings["EfContext"].ConnectionString;
            kernel.Bind<DbContext>()
                .To<EfContext>()
                .InRequestScope()
                .WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IProductRepository>().To<ProductRepository>();
        }
