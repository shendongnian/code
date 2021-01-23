    public class PropertyMap<K,V> : ICollection<V> {
        private readonly IDictionary<K,V> dict = new Dictionary<K,V>();
        private readonly Func<V,K> key;
        public PropertyMap(IDictionary<K,V> dict, Func<V,K> key) {
            this.key = key;
        }
        public void Add(V v) {
            dict.Add(key(v));
        }
        // Implement other methods of ICollection
        public this[K k] {
            get { return dict[k]; }
            set { dict[k] = value; }
        }
    }
