    public sealed class MyClass
    {
        public static MyClass Instance { get { return InstanceHolder.instance; } }
        private MyClass() {}
        private static class InstanceHolder
        {
            internal static readonly MyClass instance = new MyClass();
        }
        public static void Foo()
        {
            // Calling this won't initialize the singleton
        }
    }
