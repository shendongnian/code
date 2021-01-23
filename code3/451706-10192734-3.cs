    public class LambdaEqualityComparer<T> : IEqualityComparer<T>
    {
        Func<T, T, bool> _areEqual;
        Func<T, int> _getHashCode;
        public LambdaEqualityComparer(Func<T, T, bool> areEqual,
                                      Func<T, int> getHashCode)
        {
            _areEqual = areEqual;
            _getHashCode = getHashCode;
        }
        public LambdaEqualityComparer(Func<T, T, bool> areEqual)
            : this(areEqual, obj => obj.GetHashCode())
        {
        }
        #region IEqualityComparer<T> Members
        public bool Equals(T x, T y)
        {
            return _areEqual(x, y);
        }
        public int GetHashCode(T obj)
        {
            return _getHashCode(obj);
        }
        #endregion
    }
