    public class IXRepository : IRepository<IX>
    {
        public IEnumerable<X> Filter(Func<IX, bool> filterFunc)
        {
            ...
        }
    }
