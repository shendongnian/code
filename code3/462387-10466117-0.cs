    public class MyClass
    {
        private static readonly Lazy<MyClass> current = 
            new Lazy<MyClass>(() => new MyClass());
        public static MyClass Current
        {
            get { return current.Value; }
        }
        private MyClass()
        {
            // Initialization goes here.
        }
        public void Foo()
        {
            // ...
        }
        public void Bar()
        {
            // ...
        }
    }
    static void Main(string[] args)
    {
        MyClass.Current.Foo();   // Initialization only performed here.
        MyClass.Current.Bar();
        MyClass.Current.Foo();
    }
