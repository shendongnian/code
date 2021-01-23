    public class ClassA
    {
        private static ClassA _instance;
        private static ClassA Instance
        {
            get
            {
                if (_instance == null) _instance = new ClassA();
                return _instance;
            }
        }
        protected void sharedMethod<T>() { }
        public static void ClassMethod()
        {
            _instance.sharedMethod<object>();
        }
    }
    public class GenericClass<T> : ClassA
    {
        private static GenericClass<T> _instance;
        private static GenericClass<T> Instance
        {
            get
            {
                if (_instance == null) _instance = new GenericClass<T>();
                return _instance;
            }
        }
        public static void GenericClassMethod()
        {
            Instance.sharedMethod<T>();
        }
    }
