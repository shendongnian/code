    class MyExtendedTreeViewItem : TreeViewItem
    {
        private ItemsWrapper _items;
        public MyExtendedTreeViewItem()
        {
            _items = new ItemsWrapper(base.Items);
        }
        public new IList<MyExtendedTreeViewItem> Items { get { return _items; } }
    }
