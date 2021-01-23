    public interface IFoo
    {
        string Forty { get; set; }
        string Two { get; set; }
    }
    
    public interface IBar<T>
        where T : IFoo
    {
        // other stuff...
    
        T Answer { get; set; }
    }
    
    public class Foo : IFoo
    {
        public string Forty { get; set; }
        public string Two { get; set; }
    }
    
    public class Bar : IBar<Foo>
    {
        // other stuff
    
        public Foo Answer { get; set; }
    }
