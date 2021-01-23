    private void RegisterDependencyResolver()
            {
                var kernel = new StandardKernel();         
                var connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                kernel.Bind(typeof(DataContext)).ToMethod(context => new DataContext(connectionString));
                kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));            
                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            }
