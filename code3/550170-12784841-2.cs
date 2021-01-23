    public class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        IEqualityComparer<T> itemComparer;
        public SequenceComparer()
        {
            this.itemComparer = EqualityComparer<T>.Default;
        }
        public SequenceComparer(IEqualityComparer<T> itemComparer)
        {
            this.itemComparer = itemComparer;
        }
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (object.Equals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.SequenceEqual(y, itemComparer);
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            if (obj == null)
                return -1;
            int i = 0;
            return obj.Aggregate(0, (x, y) => x ^ new { Index = i++, Item = y }.GetHashCode());
        }
    }
