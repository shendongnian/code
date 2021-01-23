    public class FooSample<T> where T: IBar
    {
        IFoo<T> foo;
        public IQueryable Data
        {
            get { return foo.Bar; }
        }
    }
