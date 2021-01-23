    public class MyClass
    {
        private static MyClass _instance = new MyClass();
        public static MyClass Instance { get { return _instance; } }
        public int A { get; set; }
        public static int a { get { return _instance.A; } }
        private MyClass() { }
    }
