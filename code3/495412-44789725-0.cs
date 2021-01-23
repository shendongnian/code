    public class Some<T> : IOptional<T>
    {
        private readonly IEnumerable<T> _element;
        public Some(T element)
            : this(new T[1] { element })
        {
        }
        public Some()
            : this(new T[0])
        {}
        private Some(T[] element)
        {
            _element = element;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _element.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Just<T> : IMandatory<T>
    {
        private readonly T _element;
        public Just(T element)
        {
            _element = element;
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return _element;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
