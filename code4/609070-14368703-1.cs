    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            MyImage = new BitmapImage(new Uri(@"Capture.png", UriKind.RelativeOrAbsolute));
        }
        private BitmapImage _image;
        public BitmapImage MyImage
        {
            get { return _image; }
            set { _image = value; NotifyPropertyChanged("MyImage"); }
        }
        private void Storyboard1_Completed(object sender, EventArgs e)
        {
            MyImage = new BitmapImage(new Uri(@"Capture1.png", UriKind.RelativeOrAbsolute));
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
