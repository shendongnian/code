    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel = new StandardKernel();
        public T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
