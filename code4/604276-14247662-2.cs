    public partial class MainWindow : Window
    {
        public MainWindow() 
        {
            InitializeComponent();
            Items.Add("Stack");
            Items.Add("Overflow");
        }
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }
