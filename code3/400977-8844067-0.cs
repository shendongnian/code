        System.Windows.Threading.DispatcherTimer dt;
        public MainPage()
        {
            InitializeComponent();
            dt = new System.Windows.Threading.DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1000); // 1000 Milliseconds
            dt.Tick += new EventHandler(dt_Tick);
        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            dt.Stop();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            dt.Start();
        }
        void dt_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox1.Items.Count + 1); // for testing
        }
        private void PageTitle_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative)); // for testing
        }
