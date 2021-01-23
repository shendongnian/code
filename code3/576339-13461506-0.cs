    public interface IBar<T> : IQueryable<T>, IEnumerable<T> where T : class
    {
    }
    public interface IFoo<T> where T : IBar
    {
        IBar<T> Bar { get; set; }
    }
