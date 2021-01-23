    public class DepepndecyResolverMock : IDependencyResolver
    {
        private readonly IDictionary<Type, object> kernel;
        public DepepndecyResolverMock(IDictionary<Type, object> kernel)
        {
            this.kernel = kernel;
        }
    
        public object GetService(Type serviceType)
        {
            return this.kernel[serviceType];
        }
    
        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
