    public class EnumerableComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public void Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return x.SequenceEqual(y);
        }
        public void GetHashCode(IEnumerable<T> obj)
        {
            return obj.GetHashCode();
        }
    }
