    class TestCollection
    {
        public ObservableCollection<TestItem> Items { get; set; }
        List<TestItem> _items = new List<TestItem>();
        int pos = 0;
        public TestCollection(int size)
        {
            MoveNextCommand = new Command(new Action(MoveNext));
            MovePrevCommand = new Command(new Action(MovePrev));
            Items = new ObservableCollection<TestItem>();
            for (int i = 0; i < size; i++)
            {
                _items.Add(new TestItem("Item " + i.ToString()));
            }
            UpdateItems();
        }
        public void MoveNext()
        {
            pos += 10;
            if (pos > _items.Count - 10)
                pos = _items.Count - 10;
            UpdateItems();
        }
        public ICommand MoveNextCommand { get; set; }
        public ICommand MovePrevCommand { get; set; }
        public void MovePrev()
        {
            pos -= 10;
            if (pos < 0)
                pos = 0;
            
            UpdateItems();
        }
        private void UpdateItems()
        {
            Items.Clear();
            foreach (var i in _items.Skip(pos).Take(10))
            {
                Items.Add(i);
            }
       }
    }
