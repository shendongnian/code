            public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine("Width: {0}", this.Width);
            Debug.WriteLine("ActualWidth: {0}", this.ActualWidth);
            Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Width: {0}", this.Width);
            Debug.WriteLine("ActualWidth: {0}", this.ActualWidth);
        }
