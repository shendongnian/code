    public static class ClassRegistrar
    {
        private static List<Type> registered = new List<Type>();
        public static void Register(Type type)
        {
            registered.Add(type);
        }
    }
    public class MyClass
    {
        static MyClass()
        {
            ClassRegistrar.Register(typeof(MyClass));
        }
    }
