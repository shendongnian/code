    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<string> myVar = new ObservableCollection<string>();
        private bool _isScrolling;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 100; i++)
            {
                List.Add("StackOverflow " + i);
            }
        }
        public ObservableCollection<string> List
        {
            get { return myVar; }
            set { myVar = value; }
        }
    
        public bool IsScrolling
        {
            get { return _isScrolling; }
            set { _isScrolling = value; NotifyPropertyChanged("IsScrolling"); }
        }
      
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IsScrolling = !IsScrolling;
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
