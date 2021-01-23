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
    
    public class SpecificClassPool : ObjectPool
    {
        public void Add<TGenericParam>(SpecificClass<TGenericParam> obj)
        {
            Add<TGenericParam, SpecificClass<TGenericParam>>(obj);
        }
        
        public SpecificClass<TGenericParam> Get<TGenericParam>()
        {
            return Get<TGenericParam, SpecificClass<TGenericParam>>();
        }
    }
