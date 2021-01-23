    public partial class MainWindow : Window
    {
        private ObservableCollection<string> _comboItems = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            ComboItems.Add("Stack");
            ComboItems.Add("Overflow");
        }
        public ObservableCollection<string> ComboItems
        {
            get { return _comboItems; }
            set { _comboItems = value; }
        }
    }
