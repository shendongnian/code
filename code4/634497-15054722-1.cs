    public sealed class MyList<T>
    {
        public int Count { get; }
        public T this[int index] { get; set; }
        public MyList();
        public void Add(T item);
        public void RemoveAt(int index);
    }
