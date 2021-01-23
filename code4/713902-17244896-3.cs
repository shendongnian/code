    public class EnumerableComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public void Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            int x = 31;
            foreach (T element in obj)
            {
                x += 37 * element.GetHashCode();
            }
            return x;
        }
    }
