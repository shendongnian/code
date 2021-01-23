    public class ExceptionRegistry<TKey, TExceptionBase> where TExceptionBase : Exception
    {
        private readonly Dictionary<TKey, Func<TExceptionBase>> _factories = new ...;
    
        public void Register(TKey key, Func<TExceptionBase> factory)
        {
            _factories[key] = factory;
        }
    
        public TExceptionBase GetInstance(TKey key)
        {
            Func<TExceptionBase> factory;
            if(!_factories.TryGetValue(key, out factory))
                throw new InvalidOperationException("No matching factory has been found");
            return factory();
        }
    }
