    public class MyClass
    {
        private static MyClass _myClass;
        public static MyClass Static
        {
            get
            {
                return _myClass ?? (_myClass = new MyClass());
            }
        }
    }
