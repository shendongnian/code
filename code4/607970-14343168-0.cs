    class ValueIEnumerableComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<T> obj)
        {
            return obj.Sum(i => i.GetHashCode());
        }
    }
