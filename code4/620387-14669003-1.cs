    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ImageSource _myImageSource;
        public MainWindow()
        {
            InitializeComponent();
        }
        public ImageSource MyImageSource
        {
            get { return _myImageSource; }
            set { _myImageSource = value; NotifyPropertyChanged("MyImageSource"); }
        }
        private void SetImage()
        {
            // Your logic
            MyImageSource = BitmapSource.Create(colorFrame.Width, colorFrame.Height,
              96, 96, //DPI
              PixelFormats.Bgr32, //format
              null,
              pixels, //where the data is stored
              stride);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
