    public class FooContainer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Foo> Foos { get; set; }
    }
    
    public class Foo
    {
        public string Name {get; set; }
        public string Description {get; set;}
    }
