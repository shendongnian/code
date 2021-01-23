    public class CollectionEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public Equals(IEnumerable<T> x, IEnumerable<T> y) 
        { 
            return x.SequenceEqual(y); 
        }
        public GetHashCode(IEnumerable<T> obj) 
        {
            unchecked
            {
                return obj.Select(x => x.GetHashCode())
                          .Aggregate(17, (a, b) => a * 31 * b);
            }
        }
    }
