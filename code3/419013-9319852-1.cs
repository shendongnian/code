    class SortableCollection<T> : Collection<T>
    {
        private readonly List<T> _list;
        public SortableCollection() : this(new List<T>) {}
        public SortableCollection(List<T> list) : base(list)
        {
            _list = list;
        }
        public void Sort() { _list.Sort(); }
    }
