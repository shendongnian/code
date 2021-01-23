    public partial class IntroScreen : Window, INotifyPropertyChanged
    {
        private string[] files;
        private Timer timer;
        private int counter;
        private int Imagecounter;
        BitmapImage _MainImageSource = null;
        public BitmapImage MainImageSource  // Using Uri in the binding was no possible because the Source property of an Image is of type ImageSource. (Yes it is possible to write directly the path in the XAML to define the source, but it is a feature of XAML (called a TypeConverter), not WPF)
        {
            get
            {
                return _MainImageSource;
            }
            set
            {
                _MainImageSource = value;
                OnPropertyChanged("MainImageSource");  // Don't forget this line to notify WPF the value has changed.
            }
        }
        public IntroScreen()
        {
            InitializeComponent();
            DataContext = this;  // The DataContext allow WPF to know the initial object the binding is applied on. Here, in the Binding, you have written "Path=MainImageSource", OK, the "MainImageSource" of which object? Of the object defined by the DataContext.
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            setupPics();
        }
        private void setupPics()
        {
            timer = new Timer();
            timer.Elapsed += timer_Tick;
            timer.Interval = 2000;
            // Initialize "files", "Imagecounter", "counter" before starting the timer because the timer is not working in the same thread and it accesses these fields.
            files = Directory.GetFiles(@"../../Resources/Taken/", "*.jpg", SearchOption.TopDirectoryOnly);
            Imagecounter = files.Length;
            MessageBox.Show(Imagecounter.ToString());
            counter = 0;
            timer.Start();  // timer.Start() and timer.Enabled are equivalent, only one is necessary
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            // WPF requires all the function that modify (or even read sometimes) the visual interface to be called in a WPF dedicated thread.
            // IntroScreen() and MainWindow_Loaded(...) are executed by this thread
            // But, as I have said before, the Tick event of the Timer is called in another thread (a thread from the thread pool), then you can't directly modify the MainImageSource in this thread
            // Why? Because a modification of its value calls OnPropertyChanged that raise the event PropertyChanged that will try to update the Binding (that is directly linked with WPF)
            Dispatcher.Invoke(new Action(() =>  // Call a special portion of your code from the WPF thread (called dispatcher)
            {
                // Now that I have changed the type of MainImageSource, we have to load the bitmap ourselves.
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(files[counter], UriKind.Relative);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;  // Don't know why. Found here (http://stackoverflow.com/questions/569561/dynamic-loading-of-images-in-wpf)
                bitmapImage.EndInit();
                MainImageSource = bitmapImage;  // Set the property (because if you set the field "_MainImageSource", there will be no call to OnPropertyChanged("MainImageSource"), then, no update of the binding.
            }));
            if (++counter == Imagecounter)
                counter = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
