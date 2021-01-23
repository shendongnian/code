    class MultiDict<TKey, TValue>  // no (collection) base class
            {
                private Dictionary<TKey, List<TValue>> _data = new Dictionary<TKey, List<TValue>>();
    
                public void Add(TKey k, TValue v)
                {
                    // can be a optimized a little with TryGetValue, this is for clarity
                    if (_data.ContainsKey(k))
                        _data[k].Add(v);
                    else
                        _data.Add(k, new List<TValue>() { v });
                }
    
                // more members
    
                public List<TValue> GetValues(TKey key)
                {
                    if (_data.ContainsKey(key))
                        return _data[key];
                    else
                        return new List<TValue>();
                }
    
            }
