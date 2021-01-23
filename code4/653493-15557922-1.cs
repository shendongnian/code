    public class KeyFuncEqualityComparer<T> :IEqualityComparer<T>
    {
        private readonly Func<T, object> _getKey;
        public KeyFuncEqualityComparer(Func<T, object> getKey)
        {
            _getKey = getKey;
        }
        public bool Equals(T x, T y)
        {
            return _getKey(x).Equals(_getKey(y));
        }
    
        public int GetHashCode(T obj)
        {
            return _getKey(obj).GetHashCode();
        }
    }
