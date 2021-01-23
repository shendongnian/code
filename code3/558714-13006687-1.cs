    public class MainStatic<T> where T : MainStatic<T>
    {
        public static void Foo()
        {
        }
        static MainStatic()
        {
            RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
        }
    }
    public class SubStatic : MainStatic<SubStatic>
    {
        public static void Bar()
        {
        }
    }
    public class Instance
    {
        public void FooBar()
        {
            SubStatic.Foo();
            SubStatic.Bar();
        }
    }
