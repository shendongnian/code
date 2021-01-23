    public partial class MyItemsControl : UserControl
    {
        private ObservableCollection<MyItem> _Items = new ObservableCollection<MyItem>();
        public ObservableCollection<MyItem> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
            }
        }
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            txtHeader.Text = Items.Count + " Item(s)";
        }
        public MyItemsControl()
        {
            InitializeComponent();
            Items.CollectionChanged += Items_CollectionChanged;
            this.DataContext = this;
        }
    }
