    class Items: IEnumerable<Item>
    {
        private readonly List<Item> _items = new List<Item>();
        public void Add(Item item)
        {
            _items.Add(item);
        }
        public int Count
        {
            get { return _items.Count; }
        }
        public void Move(int oldIndex, int newIndex)
        {
            Item item = _items[oldIndex];
            _items.RemoveAt(oldIndex);
            _items.Insert(newIndex, item);
        }
        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
