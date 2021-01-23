    public class Foo
    {
        public Foo()
        {
            SomeBar = new Bar();
        }
    
        public class Bar
        {
            public string SomeProperty { get; set; }
        }
        
        public Bar SomeBar { get; set; }
    }
