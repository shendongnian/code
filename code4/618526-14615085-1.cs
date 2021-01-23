    public class RepositoryFactory : IRepositoryFactory
    {
        private IKernel _kernel;
        public RepositoryFactory(IKernel kernel)
        {
            _kernel = kernel;
        }
        public T CreateNew<T>(string sessionId)
        {
            return
                _kernel.Get<T>(new ConstructorArgument("sessionId", sessionId));
        }
    }
