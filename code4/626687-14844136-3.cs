    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool _imageVisible;
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool ImageVisible
        {
            get { return _imageVisible; }
            set { _imageVisible = value; NotifyPropertyChanged("ImageVisible"); }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageVisible = !ImageVisible;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
    }
