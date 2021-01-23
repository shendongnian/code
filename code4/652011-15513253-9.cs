    public partial class MainWindow : Window
    {
        public MainWindow() 
        {
            InitializeComponent();
            Items.Add("Item1");
            Items.Add("Item2");
            Items.Add("Item3");
            Items.Add("Item4");
        }
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }
