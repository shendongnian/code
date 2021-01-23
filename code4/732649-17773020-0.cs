        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindowLoaded;
        }
        void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindowLoaded;
            Window1 window1 = new Window1();
            window1.Dispatcher.BeginInvoke((SendOrPostCallback) delegate
                {
                    Thread.Sleep(3000);
                    Hide();
                    window1.Show();
                }, new object[] {null});
        }
