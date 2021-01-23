        public MainWindow()
        {
            InitializeComponent();
            myBug.Text = "blubb";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBug.Text = "new blubb";
        }
