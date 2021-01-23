    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private MyData _myData;
        public MainWindow()
        { 
            InitializeComponent();
            MyData = new MyData("Red");
        }
        public MyData MyData
        {
            get { return _myData; }
            set { _myData = value; NotifyPropertyChanged("MyData"); }
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
