    public class Class1
    {
        private Class1()
        {
        }
        private static Class1 _object;
        public static Class1 Instance
        {
            get
            {
                if (_object == null)
                    _object = new Class1();
                return _object;
            }
        }
        public bool MyBoolProperty { get; set; }
    } 
