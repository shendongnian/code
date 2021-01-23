    public class Item<T>
    {
        private List<T> _items;
        private int _index;
        public Item(List<T> items, int index)
        {
            _items = items;
            _index = index;
        }
        public T Value
        {
            get { return _items[_index]; }
            set { _items[_index] = value; }
        }
    }
