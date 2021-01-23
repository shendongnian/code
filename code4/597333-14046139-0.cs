        class FileInfoComparer<T> : IEqualityComparer<T>
        {
            public FileInfoComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
            {
                _equals = equals;
                _getHashCode = getHashCode;
            }
            readonly Func<T, T, bool> _equals;
            public bool Equals(T x, T y)
            {
                return _equals(x, y);
            }
            readonly Func<T, int> _getHashCode;
            public int GetHashCode(T obj)
            {
                return _getHashCode(obj);
            }
        } 
