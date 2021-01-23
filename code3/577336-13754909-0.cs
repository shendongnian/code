        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollBar verticalBar;
            verticalBar = ((FrameworkElement)VisualTreeHelper.GetChild(mainScrollViewer, 0)).FindName("VerticalScrollBar") as ScrollBar;
            verticalBar.ValueChanged += verticalBar_ValueChanged;
        }
        void verticalBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double newVerticalOffset =  e.NewValue;
            // Set the offset of your other control here, using newVerticalOffset
        }
