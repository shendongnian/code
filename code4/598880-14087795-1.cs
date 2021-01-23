    public class KeyDictionary<T> : Dictionary<T, bool>
    {
        public void Add(T key)
        {
            base.Add(key, false);
        }
    }
