    interface IReferencedQueryable<T> : IQueryable<T>
    {
        IEnumerable<T> Source { get; }
    }
    
    static class IReferencedQueryableExtensions
    {
        public static IReferencedQueryable<T> AsReferencedQueryable<T>(
            this IEnumerable<T> source)
        {
            return ReferencedQueryable.From(source);
        }
        
        class ReferencedQueryable<T> : IReferencedQueryable<T>
        {
            public IEnumerable<T> Source { get; private set; }
    
            ReferencedQueryable(IEnumerable<T> source)
            {
                Source = source;
            }
            
            static IReferencedQueryable<T> From(IEnumerable<T> source)
            {
                return new ReferencedQueryable(source);
            }
            
            // all the IQueryable members would be 
            // implemented through AsQueryable()
            // ...
        }
    
        public static IReferencedQueryable<T> Where<T>(
            this IReferencedQueryable<T> source, 
            Expression<Func<T, bool>> predicate)
        {
            return ReferencedQueryable.From(
                ((IQueryable<T>)source).Where(predicate));
        }
        
        // do the same for all the Linq extension methos you want to support
    }
