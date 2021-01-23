    public partial class MainWindow : Window
    {
        class ListItemViewModel
        {
            public string Name1 { get; set; }
            public string Name2 { get; set; }
        }
        ObservableCollection<ListItemViewModel> items;
        public MainWindow()
        {
            InitializeComponent();
            // Populate list...
            // In reality, populate each instance based on your related item(s) from your data model.
            items = new ObservableCollection<ListItemViewModel>
            {
                new ListItemViewModel { Name1 = "Foo1", Name2 = "Foo2" },
                new ListItemViewModel { Name1 = "Bar1", Name2 = "Bar2" }
            };
            listBox1.ItemsSource = items;
            items.CollectionChanged += items_CollectionChanged;
        }
        
        void items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    for (int i = 0; i < e.OldItems.Count; i++)
                    {
                        var itemVm = e.OldItems[i] as ListItemViewModel;
                        // Update underlying model collection(s).
                    }
                    break;
                //  Handle cases Add and/or Replace...
            }
        }
    }
