    class SequenceComparer<T,U> : IEqualityComparer<T> where T: IEnumerable<U>
    {
        public bool Equals(T x, T y)
        {
            return Enumerable.SequenceEqual(x, y);
        }
        public int GetHashCode(T obj)
        {
            int hash = 19;
            foreach (var item  in obj)
            {
                hash = hash * 31 + item.GetHashCode();
            }
            return hash;
        }
    }
