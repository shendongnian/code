    public class PoppableDictionary<T, V> : Dictionary<T, V>
    {
        public V Pop(T key)
        {
            V value = this[key];
            this.Remove(key);
            return value;
        }
    }
