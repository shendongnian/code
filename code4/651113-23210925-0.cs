    public class NInjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot _resolutionRoot;
        
        public NInjectDependencyScope(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }
        public void Dispose()
        {
            var disposable = _resolutionRoot as IDisposable;
            
            if (disposable != null)
                disposable.Dispose();
            
            _resolutionRoot = null;
        }
        
        public object GetService(Type serviceType)
        {
            return GetServices(serviceType).FirstOrDefault();
        }
        
        public IEnumerable<object> GetServices(Type serviceType)
        {
            var request = _resolutionRoot.CreateRequest(serviceType, null, new IParameter[0], true, true);
            
            return _resolutionRoot.Resolve(request);
        }
    }
