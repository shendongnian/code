    public class CustomEqualityComparer<T> : IEqualityComparer<T>
    {
        private Func<T, T, bool> _comparison;
        private Func<T, int> _getHashCode;
    
        public CustomEqualityComparer
        (
            Func<T, T, bool> comparison,
            Func<T, int> getHashCode
        )
        {
            if (ReferenceEquals(comparison, null))
            {
                throw new ArgumentNullException("comparison");
            }
            else if (ReferenceEquals(getHashCode, null))
            {
                throw new ArgumentNullException("getHashCode");
            }
            else
            {
               _comparison = comparison;
               _getHashCode = getHashCode;
            }
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
