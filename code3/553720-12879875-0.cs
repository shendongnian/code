    public class GenericDictionary<K, V> : Dictionary<K, V>
    {
        public K Key { get; set; }
        public V this[K key]
        {
            get
            {
                Key = key;
                return this.First(x => x.Key.Equals(key)).Value;
            }
            set
            {
                Key = key;
                base[key] = value;
            }
        }
    }
