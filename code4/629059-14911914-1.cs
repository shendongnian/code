    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private string _xmlContentFile;
        public string XmlContentFile
        {
            get
            {
                return _xmlContentFile ;
            }
            set 
            { 
                _xmlContentFile = value;
                OnPropertyChanged("XmlContentFile");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            XmlContentFile = "New Value !";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
