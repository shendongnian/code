    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _myTextToValidate;
        public MainWindow()
        {
            InitializeComponent();
        }
        public string MyTextToValidate
        {
            get { return _myTextToValidate; }
            set { _myTextToValidate = value; NotifyPropertyChanged("MyTextToValidate"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
