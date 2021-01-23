    class Singleton<T>
    {
        // Store our list of singletons
        static List<Singleton<T>> instances = new List<Singleton<T>>();
        static T instance;
        protected Singleton() { }
        public static T GetInstance()
        {
            // Either return the existing instnace, or create a new one
            if (Singleton<T>.instance == null)
                Singleton<T>.instance = (T)Activator.CreateInstance(typeof(T));
            // The compiler doesn't understand curious recursiveness, so just use
            // dynamic to force runtime re-evaluation of the type hierarchy. 
            // Alternatively, if you don't like dynamic statements
            // (they make me a bit leery myself), you could just make an interface
            // ISingleton, and have all of your singletons implement that. Then change your list to
            // List<ISingleton> instances. But dynamic works as is.
            instances.Add((dynamic)Singleton<T>.instance);
            return Singleton<T>.instance;
        }
    }
    class MyClass : Singleton<MyClass>
    {
    }
    public static void Main()
    {
        MyClass my = MyClass.GetInstance();
    }
