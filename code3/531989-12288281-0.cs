    public class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> equalityComparer;
        private readonly Func<T, int> hashFunc;
        public GenericEqualityComparer(Func<T, T, bool> compareFunc, Func<T,int> hashFunc)
            :this(compareFunc)
        {
            this.equalityComparer = compareFunc;
            this.hashFunc = hashFunc;
        }
        public GenericEqualityComparer(Func<T, T, bool> compareFunc)
        {
            this.equalityComparer = compareFunc;
            this.hashFunc = o => o.GetHashCode();
        }
        public bool Equals(T x, T y)
        {
            return equalityComparer(x, y);
        }
        public int GetHashCode(T obj)
        {
            return hashFunc(obj);
        }
    }
