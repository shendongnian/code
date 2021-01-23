    // Create a common interface that all singletons use. This allows 
    // us to add them all to a list.
    interface ISingleton { }
    class Singleton<T> : ISingleton
    {
        // Store our list of ISingletons
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
                // Also, compiler isn't built to follow curious recursiveness,
                // so use a dynamic statement to force runtime re-evaluation of 
                // the type hierarchy. Try to avoid dynamic statements in general
                // but in this case its useful.
                instances.Add((dynamic)Singleton<T>.instance);
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
