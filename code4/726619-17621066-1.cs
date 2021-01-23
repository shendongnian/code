    interface IThing { }
    
    abstract class BaseClass
    {
        internal T AsInterface<T> where T : class
        {
            return this as T;
        }
    }
    
    class MyClass : BaseClass, IThing { }
    class DictionaryClass
    {
        private readonly Dictionary<Type, BaseClass> dictionary;
        public void Add<T>(BaseClass base)
        {
            if (base is T)
            {
                dictionary.Add(typeof(T), base);
            }
        }
        public T Get<T>() where T : class
        {
            return dictionary[typeof(T)].AsInterface<T>();
        }
    }
