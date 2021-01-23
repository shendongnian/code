    public partial class MainWindow : Window
    {
        private ObservableCollection<string> _extras = new ObservableCollection<string>( );
        public ObservableCollection<string> Extras
        {
            get { return _extras; }
            set
            {
                if (value != _extras)
                {
                    _extras = value;
                }
            }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Extras.Add("Additional");
        }
    }
