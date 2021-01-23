    public class ValueArray<T>
    {
        private T[] _array;
        public T this[int idx]
        {
            get { return _array[idx]; }
            set { _array[idx] = value; }
        }
        public ValueArray(T[] array)
        {
            initializeArray(array);
        }
        public ValueArray(ValueArray<T> other)
        {
            initializeArray(other._array);
        }
        private void initializeArray(T[] array)
        {
            _array = new T[array.Length];
            array.CopyTo(_array, 0);
        }
    }
