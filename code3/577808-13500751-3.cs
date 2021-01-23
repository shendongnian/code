    public class FixedQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> _list;
        public int Capacity { get; private set; }
        public FixedQueue(int capacity)
        {
            this.Capacity = capacity;
            _list = new LinkedList<T>();
        }
        public T Enqueue(T item)
        {
            _list.AddLast(item);
            if (_list.Count > Capacity)
                return Dequeue();
            return default(T);
        }
        public T Dequeue()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Empty Queue");
            var item = _list.First.Value;
            _list.RemoveFirst();
            return item;
        }
        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Empty Queue");
            return _list.First.Value;
        }
        public void Clear()
        {
            _list.Clear();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
