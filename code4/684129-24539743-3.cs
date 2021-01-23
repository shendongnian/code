    public class NinjectDependencyResolver : IDependencyResolver
    {
        readonly IKernel _kernel;
    
        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }
    
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }
    
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    
        void AddBindings()
        {
            // Remember to add bindings here.
            _kernel.Bind<IAccountRepository>().To<EFAccountRepository>();
        }
    }
