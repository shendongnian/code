    public interface IFoo
    {
        string Name {get;}
        string ToXml();    
    }
    
    public class Foo : IFoo
    {
        public Foo(string name)
        {
            Name = name;
        }
        public string Name {get; private set;}
        public string ToXml()
        {
            return "<derp/>";
        }
    }
