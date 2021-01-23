    public class NoCurrentItemViewModel
    {
        public NoCurrentItemViewModel()
        {
            _items = new ObservableCollection<NoCurrentItemDetail>
                        {
                            new NoCurrentItemDetail{Name = "one"},
                            new NoCurrentItemDetail{Name = "two"},
                        };
            ClearCommand = new RelayCommand(Clear);
        }
        public ICommand ClearCommand { get; private set; }
        private void Clear()
        {
            _items.Clear();
        }
        private readonly ObservableCollection<NoCurrentItemDetail> _items;
        public IEnumerable<NoCurrentItemDetail> Items
        {
            get { return _items; }
        }
    }
    public class NoCurrentItemDetail
    {
        public NoCurrentItemDetail()
        {
            DoSomethingCommand = new RelayCommand(DoSomething);
        }
        private void DoSomething()
        {
            Debug.WriteLine("Do something: " + Name);
        }
        public ICommand DoSomethingCommand { get; private set; }
        public string Name { get; set; }
    }
