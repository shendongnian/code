    public class FixedQueue<T> : IEnumerable<T>
    {
        private List<T> _list;
        public int Capacity { get; set; }
        public FixedQueue(int capacity)
        {
            this.Capacity = capacity;
            _list = new List<T>(capacity);
        }
        public T Enqueue(T item)
        {
            _list.Add(item);
            if (_list.Count > Capacity)
                return Dequeue();
            return default(T);
        }
        public T Dequeue()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Empty Queue");
            var item = _list[0];
            _list.RemoveAt(0);
            return item;
        }
        public T Peek()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Empty Queue");
            return _list[_list.Count - 1];
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
