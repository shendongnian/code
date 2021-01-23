    class ConstantSizeReadOnlyArrayWrapper<T> : IList<T>
    {
        private readonly T[] _array;
        private readonly int _constantSize;
        private readonly T _padValue;
        public ConstantSizeReadOnlyArrayWrapper(T[] array, int constantSize, T padValue)
        {
             //parameter validation omitted for brevity
            _array = array;
            _constantSize = constantSize;
            _padValue = padValue;
        }
        private int MissingItemCount
        {
            get { return _constantSize - _array.Length; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            //maybe you don't need to implement this, or maybe just returning _array.GetEnumerator() would suffice.
            return _array.Concat(Enumerable.Repeat(_padValue, MissingItemCount)).GetEnumerator();
        }
        public int Count
        {
            get { return _constantSize; }
        }
        public bool IsReadOnly
        {
            get { return true; }
        }
        public int IndexOf(T item)
        {
            var arrayIndex = Array.IndexOf(_array, item);
            if (arrayIndex < 0 && item.Equals(_padValue))
                return _array.Length;
            return arrayIndex;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _constantSize)
                    throw new IndexOutOfRangeException();
                return index < _array.Length ? _array[index] : _padValue;
            }
            set { throw new NotSupportedException(); }
        }
    }
