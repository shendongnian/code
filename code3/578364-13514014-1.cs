    namespace ns.pc
    {
        public class Bar
        {
            public Foo ProcessAndCreateFoo()
            {
                // ...
                Foo foo = new FooExtended(o);
                return foo;
            }
        }
    
        public class Foo
        {
            public Foo (Object o) 
            {}
        }
    
        public class FooExtended : Foo
        {
            public FooExtended (Object o) 
            {}
        }
    }
