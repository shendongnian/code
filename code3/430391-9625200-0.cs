    public class ForceableEnumerable<T> : IEnumerable<T>
    {
        IEnumerable<T> _enumerable;
        IEnumerator<T> _enumerator;
        public ForceableEnumerable(IEnumerable<T> enumerable)
        {
            _enumerable = enumerable;
        }
        public void ForceEvaluation()
        {
            if (_enumerator != null) {
                while (_enumerator.MoveNext()) {
                }
            }
        }
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            _enumerator = _enumerable.GetEnumerator();
            return _enumerator;
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
