    public class MovableDictionary<K, V> // : IDictionary<K, V>, IReadOnlyDictionary<K, V>...
    {
        private Dictionary<K, V> _map;
        // Implement all Dictionary<T>'s methods by calling Map's ones.
        public Dictionary<K, V> Move()
        {
            var result = Map;
            _map = null;
            return result;
        }
        private Dictionary<K, V> Map
        {
            get
            {
                if (_map == null)
                    _map = new Dictionary<K, V>();
                return _map;
            }
        }
    }
