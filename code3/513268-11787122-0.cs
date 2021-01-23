    public class Registry<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        private object Lock = new object();
    
        public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            TValue value;            
            if (!dictionary.TryGetValue(key, out value))
            {
                lock(Lock)
                {
                  var snapshot = new Dictionary<TKey, TValue>(dictionary);
                  if (!snapshot.TryGetValue(key, out value))
                  {
                      value = valueFactory(key);
                      snapshot.Add(key, value);
                      dictionary = snapshot;
                  }
                }   
            }
            return value;
        }
    }
