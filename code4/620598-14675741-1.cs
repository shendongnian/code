    public class IEnumerableComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return Object.ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y));
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            if (obj == null)
                return 0;
            // Will not throw an OverflowException
            unchecked
            {
                return obj.Select(e => e.GetHashCode()).Aggregate(17, (a, b) => 23 * a + b);
            }
        }
    }
    
