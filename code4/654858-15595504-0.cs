    public class MyClass
    {
        private int i;
        public int Foo { get { return i++; } } 
    }
    public static class SharedResources
    {
        public static const string SharedString;
        public static readonly MyClass SharedMyClass;
    }
