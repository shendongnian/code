    interface ISingleton { }
    class Singleton<T> : ISingleton
    {
        // Store our list of singletons
        static List<ISingleton> instances = new List<ISingleton>();
        static T instance;
        protected Singleton() { }
        public static T GetInstance()
        {
            // Either return the existing instnace, or create a new one
            if (Singleton<T>.instance == null)
            {
                Singleton<T>.instance = (T)Activator.CreateInstance(typeof(T));
 
                // Use a common interface so they can all be stored together.
                // Avoids the previously mentioned co-variance problem.
                instances.Add(Singleton<T>.instance);
            }
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
