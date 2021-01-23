    public sealed class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TileViewItem> Items
        {
          get { return _items; }
          private set { _items = value; RaisePropertyChanged(); }
        }
        public ITaskCompletionNotifier Initialization { get; private set; }
        public MyViewModel()
        {
            Initialization = TaskCompletionNotifierFactory.Create(InitializeAsync());
        }
        private async Task InitializeAsync()
        {
            var ret = await I2ADataServiceHelper.GetTileViewItemsAsync();
            this.Items = new ObservableCollection<TileViewItem>(ret);
        }
    }
