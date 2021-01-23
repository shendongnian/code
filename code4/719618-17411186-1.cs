    public sealed class Class1
    {
        private static readonly Lazy<Class1> lazy =
            new Lazy<Class1>(() => new Class1());
        public static Class1 Instance { get { return lazy.Value; } }
        private Class1()
        {
        }
        public string Foo()
        {
            return "HI THERE";
        }
    }
