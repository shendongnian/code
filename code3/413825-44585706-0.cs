    class Example
    {
        public class Object1
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
        }
        public class Object2
        {
            private readonly Object1 _object1;
            public Object2()
            {
                _object1 = new Object1();
            }
            public int Property1
            {
                get { return _object1.Property1; }
                set { _object1.Property1 = value; }
            }
            public string Property2
            {
                get { return _object1.Property2; }
                set { _object1.Property2 = value; }
            }
            public static implicit operator Object1(Object2 o)
            {
                return o._object1;
            }
        }
    }
