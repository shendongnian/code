    public class SpringDependencyResolver : IDependencyResolver
    {
        private readonly IApplicationContext _context;
    
        public SpringDependencyResolver(IApplicationContext context)
        {
            _context = context;
        }
    
        public object GetService(Type serviceType)
        {
            var dictionary = _context.GetObjectsOfType(serviceType).GetEnumerator();
    
            dictionary.MoveNext();
            try
            {
                return dictionary.Value;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    
        public IEnumerable<object> GetServices(Type serviceType)
        {
    			return _context.GetObjectsOfType(serviceType).Cast<object>();
        }
    }
