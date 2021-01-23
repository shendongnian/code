    public interface IRepository<T> : IDisposable
    {
        IList<T> Get(DateTime mostRecentRead);
    }
    public class FooRepo : IRepository<Foo>
    {
        public IList<Foo> Get(DateTime mostRecentRead)
        {
            // Foo Implementation
        }
    }
    
    public class BarRepo : IRepository<Bar>
    {
        public IList<Bar> Get(DateTime mostRecentRead)
        {
            // Bar Implemenation
        }
    }
