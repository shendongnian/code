        public MainWindow()
        {
            InitializeComponent();
            EventManager.RegisterClassHandler(typeof(Image), Image.MouseDownEvent,
                  new RoutedEventHandler(OnMouseDown));
        }
        private void OnMouseDown(object sender, RoutedEventArgs e)
        {
            (sender as Image).Visibility = System.Windows.Visibility.Collapsed;
        }
