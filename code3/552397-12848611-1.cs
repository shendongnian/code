    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private double _red = 1;
        public double Red
        {
            get { return _red; }
            set
            {
                _red = value;
                OnPropertyChanged("Red");
            }
        }
    
        private double _green = 1;
        public double Green
        {
            get { return _green; }
            set
            {
                _green = value;
                OnPropertyChanged("Green");
            }
        }
    
        private double _blue = 1;
        public double Blue
        {
            get { return _blue; }
            set
            {
                _blue = value;
                OnPropertyChanged("Blue");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
