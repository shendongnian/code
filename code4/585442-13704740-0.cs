    public class SelfInitializingArray<T> : IEnumerable<T> where T : class
    {
        private Func<T> _builder;
        private T[] _items;
        
        /// <summary>
        /// Initializes a new instance of the SelfInitializingList class.
        /// </summary>
        public SelfInitializingArray(int size, Func<T> builder)
        {
            _builder = builder;
            _items = new T[size];
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                yield return ItemOrDefaultAtIndex(i);
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public T this[int index]
        {
            get
            {
                return ItemOrDefaultAtIndex(index);
            }
            set
            {
                _items[index] = value;
            }
        }
        private T ItemOrDefaultAtIndex(int index)
        {
            if (_items[index] == null)
                _items[index] = _builder();
            return _items[index];
        }
    }
