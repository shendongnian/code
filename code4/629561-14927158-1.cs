    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        private Uri _imageSource;
        public Uri ImageSource
        {
            get { return _imageSource; }
            set { _imageSource = value; NotifyPropertyChanged("ImageSource"); }
        }
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ImageTools.IO.Decoders.AddDecoder<GifDecoder>();
            this.DataContext = this;
            ImageSource = new Uri("http://c.wrzuta.pl/wi7505/bcd026ca001736004fc76975/szczur-piwo-gif-gif", UriKind.Absolute);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ImageSource = new Uri("http://0-media-cdn.foolz.us/ffuuka/board/wsg/image/1338/94/1338947099997.gif", UriKind.Absolute);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="property">The property.</param>
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
