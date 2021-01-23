        public class A
        {
            static A()
            {
                Console.WriteLine("Hello from static A");
            }
    
            public A()
            {
                Console.WriteLine("Hello from non-static A");
            }
        }
    
        public class B : A
        {
            static B()
            {
                Console.WriteLine("Hello from static B");
            }
    
            public B() : base() //explicit so you know B() will call A()
            {
                Console.WriteLine("Hello from non-static B");
            }
        }
