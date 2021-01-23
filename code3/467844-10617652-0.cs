    public class Base
    {
        public T As<T>() where T : Base, new()
        {
            return this as T ?? new T();
        }
    }
