     DispatcherTimer dt = new DispatcherTimer();
    
        public MainPage()
        {
            InitializeComponent();
            dt.Interval = new TimeSpan(0, 0, 0, 1);
            dt.Tick += new EventHandler(Ticked);
        }
       private void Ticked(object sender, EventArgs e)
        {
            MyPlayer.Play();
            dt.Stop();
        }
     private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyPlayer.Play();
            dt.Start();
        }
