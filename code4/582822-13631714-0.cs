    class Base
    {
        private static readonly IDictionary<Type, int> instanceCounterMap
            = new Dictionary<Type, int>();
        protected int _id;
    
        protected Base()
        {
            // I don't normally like locking on other objects, but I trust
            // Dictionary not to lock on itself
            lock (instanceCounterMap)
            {
                // Ignore the return value - we'll get 0 if it's not already there
                instanceCounterMap.TryGetValue(GetType(), out _id);
                instanceCounterMap[GetType()] = _id + 1;    
            }
        }
    }
