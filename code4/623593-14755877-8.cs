    class Singleton<T>
    {
        static T instance;
        protected Singleton() { }
        public static T GetInstance()
        {
            // Either return the existing instnace, or create a new one
            if (Singleton<T>.instance == null)
                Singleton<T>.instance = (T)Activator.CreateInstance(typeof(T));
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
