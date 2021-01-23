    [System.Diagnostics.DebuggerNonUserCode]
    public class CustomEqualityComparer<T> : IEqualityComparer<T>
    {
        private Func<T, T, bool> _comparison;
        private Func<T, int> _getHashCode;
    
        public CustomEqualityComparer(Func<T, T, bool> comparison, Func<T, int> getHashCode)
        {
            _comparison = comparison.NotNullArgument("comparison");
            _getHashCode = getHashCode.NotNullArgument("getHasCode");
        }
    
        public bool Equals(T x, T y)
        {
            return _comparison.Invoke(x, y);
        }
    
        public int GetHashCode(T obj)
        {
            return _getHashCode.Invoke(obj);
        }
    }
