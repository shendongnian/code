    public class TypedDictionary {
        private readonly Dictionary<Type, object> dict = new Dictionary<Type, object>();
        
        public void Add<T>(T item) {
            dict.Add(typeof(T), item);
        }
        
        public T Get<T>() { return (T) dict[typeof(T)]; }
    }
