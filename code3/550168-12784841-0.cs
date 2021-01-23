    public class ListComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        IEqualityComparer<T> itemComparer;
        public ListComparer()
        {
            this.itemComparer = EqualityComparer<T>.Default;
        }
        public ListComparer(IEqualityComparer<T> itemComparer)
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
            return obj == null ? -1 : obj.Count();
        }
    }
