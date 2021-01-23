    public class MeanException : Exception
    {
        public MeanException() : base() { }
        public MeanException(string message) : base(message) { }
    }
    public static IEnumerable<T> Break<T>(this IEnumerable<T> source)
        where T : new()
    {
        if (source != null)
        {
            throw new MeanException("Sequence was evaluated");
        }
        if (source == null)
        {
            throw new MeanException("Sequence was evaluated");
        }
    
        //unreachable
    
        //this will make this an iterator block so that it will have differed execution,
        //just like most other LINQ extension methods
        yield return new T();
    }
    
    public static IEnumerable<int> getQuery()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
    
        var query = list.Select(n => n + 1)
            .Break()
            .Where(n => n % 2 == 0);
    
        return query;
    }
