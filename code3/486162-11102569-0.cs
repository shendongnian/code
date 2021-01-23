    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public bool Flag { get; set; }
        
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Flag = true;
            OnPropertyChanged("Flag");
        }
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
