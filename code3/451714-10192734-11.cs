    public class AutoEqualityComparer<T> : IEqualityComparer<T>
    {
        private Func<T, object>[] _propertyAccessors;
        public AutoEqualityComparer(params Func<T, object>[] propertyAccessors)
        {
            _propertyAccessors = propertyAccessors;
        }
        #region IEqualityComparer<T> Members
        public bool Equals(T x, T y)
        {
            foreach (var getProp in _propertyAccessors) {
                if (!getProp(x).Equals(getProp(y))) {
                    return false;
                }
            }
            return true;
        }
        public int GetHashCode(T obj)
        {
            int hash = 0;
            foreach (var getProp in _propertyAccessors) {
                hash = hash ^ getProp(obj).GetHashCode();
            }
            return hash;
        }
        #endregion
    }
