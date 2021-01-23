    public interface IBar<T> : IQueryable<T>, IEnumerable<T> where T : class   
    {
        T Bar { get; set;}
    }
    public class Foo<T>
    {  
        IFoo<T> foo;
        public IQueryable<T> Data
        {
            get { return foo.Bar; }
        }
    }
