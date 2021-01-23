    public class Item
    {
        public Item() 
        {
            _col = new ObservableCollection<Item>();
            _col.CollectionChanged +=
                new NotifyCollectionChanged(ItemChildren_CollectionChanged);
        }
        public Header { get; set; }
        public ObservableCollection<Item> ItemChildren
        { get { return _col; } }
        public Item Parent { get { return _parent; } }
        private void ItemChildren_CollectionChanged(
            object sender,
            NotifyCollectionChangedEventArgs e)
        {
            // for all newly added items: item._parent = this;
            // for all removed items: item._parent = null;
        }
        private Item _parent;
        private ObservableCollection<Item> _col;
    }
