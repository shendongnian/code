    public class Foo1Sample
    {  
        IFoo<Bar1> foo;
        public IQueryable Data
        {
            get { return foo.Bar; }
        }
    }
