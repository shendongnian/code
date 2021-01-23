    public class IndexedDictionary<T, U>
    {
        private Dictionary<T,U> dictionary = new Dictionary<T,U>();
        private List<U> list = new List<U>();
        public void Add(T key, U value)
        {
            list.Add(value);
            dictionary.Add(key, value);
        }
        public U this[int index]
        {
           get { return list[index]; }
        }
        public U this[T key]
        {
           get { return dictionary[key]; }
        }
    }
