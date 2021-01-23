    public class NestedDictionary<K, V> : Dictionary<K, NestedDictionary<K, V>>
        {
            public V Value { set; get; }
    
            public new NestedDictionary<K, V> this[K key]
            {
                set { base[key] = value; }
    
                get
                {
                    if (!base.Keys.Contains<K>(key))
                    {
                        base[key] = new NestedDictionary<K, V>();
                    }
                    return base[key];
                }
            }
        }
