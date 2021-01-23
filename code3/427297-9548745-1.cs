    // helper class to make creating the comparers easier
    public static class ProjectionEqualityComparer
    {
        public static ProjectionEqualityComparer<TSource, TKey> Create<TSource, TKey>(Func<TSource, TKey> selector, IEqualityComparer<TKey> comparer = null)
        {
            return new ProjectionEqualityComparer<TSource, TKey>(selector, comparer);
        }
    }
    
    // the actual comparer
    public class ProjectionEqualityComparer<TSource, TKey> : EqualityComparer<TSource>
    {
        private Func<TSource, TKey> selector;
        private IEqualityComparer<TKey> comparer;
        public ProjectionEqualityComparer(Func<TSource, TKey> selector, IEqualityComparer<TKey> comparer = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            this.selector = selector;
            this.comparer = comparer ?? EqualityComparer<TKey>.Default;
        }
        
        public override bool Equals(TSource x, TSource y)
        {
            var xKey = selector(x);
            var yKey = selector(y);
            return comparer.Equals(xKey, yKey);
        }
        
        public override int GetHashCode(TSource source)
        {
            var key = selector(source);
            return key.GetHashCode();
        }
    }
