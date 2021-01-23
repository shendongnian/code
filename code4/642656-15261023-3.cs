    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Records.Add(new string[3] { "1", "2", "3" });
            Records.Add(new string[3] { "10", "20", "30" });
            Records.Add(new string[3] { "100", "200", "300" });
        }
        private ObservableCollection<string[]> _records = new ObservableCollection<string[]>();
        public ObservableCollection<string[]> Records
        {
            get { return _records; }
            set { _records = value; }
        }
    }
