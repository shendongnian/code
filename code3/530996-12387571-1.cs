        public class A
        {
            public A()
            {
                Values = new List<B>();
            }
            public string prop1 {get; set;}
            public List<B> Values { get; set; }
        }
        public class B
        {
            public string prop2 { get; set; }
            public string prop3 { get; set; }
        }
