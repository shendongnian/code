        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items ?? (_items = new ObservableCollection<Item>()); }
        }
