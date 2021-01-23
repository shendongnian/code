    class SortableCollection<T> : Collection<T>
    {
        public SortableCollection() : this(new List<T>()) {}
        public SortableCollection(List<T> list) : base(list) {}
        public void Sort() { ((List<T>)Items).Sort(); }
    }
