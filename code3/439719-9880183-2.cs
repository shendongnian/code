    class ItemsWrapper : IList<MyExtendedTreeViewItem>
    {
        private IList<TreeViewItem> _baseItems;
        public ItemsWrapper(IList<TreeViewItem> baseItems)
        {
            _baseItems = baseItems;
        }
        public void Add(MyExtendedTreeViewItem item)
        {
            _baseItems.Add(item);
        }
        // much of implementation omitted here for brevity
        public MyExtendedTreeViewItem this[int index]
        {
            get { return (MyExtendedTreeViewItem)_baseItems[index]; }
            set { _baseItems[index] = value; }
        }
    }
