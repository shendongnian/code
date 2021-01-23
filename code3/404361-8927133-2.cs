    public class ObjectPool
    {
        Dictionary<Type, object> _objectPool = new Dictionary<Type, object>();
        
        public void Add<TKey, TValue>(TValue value)
        {
            _objectPool.Add(typeof(TKey), value);
        }
        
        public TValue Get<TKey, TValue>() where TValue : class
        {
            object value;
            if(_objectPool.TryGetValue(typeof(TKey), out value))
                return value as TValue;
            return null;
        }
    }
    
    public class GenericClassPool : ObjectPool
    {
        public void Add<TGenericParam>(GenericClass<TGenericParam> obj)
        {
            Add<TGenericParam, GenericClass<TGenericParam>>(obj);
        }
        
        public GenericClass<TGenericParam> Get<TGenericParam>()
        {
            return Get<TGenericParam, GenericClass<TGenericParam>>();
        }
    }
