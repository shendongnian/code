    public class SimpleDependencyFactory<T> where T : class, new()
    {
        public T Create()
        {
            return new T();
        }
    }
    
