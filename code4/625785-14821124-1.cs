    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _isLoggedIn;
        public MainWindow()
        {
            InitializeComponent();  
        }
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set { _isLoggedIn = value; NotifyPropertyChanged("IsLoggedIn"); }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            IsLoggedIn = !IsLoggedIn;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
     }
