     public partial class MainPage : PhoneApplicationPage
    {
        private WatchViewModel watch;
        public MainPage()
        {
            InitializeComponent();
             watch = new WatchViewModel();
            watch.GetWatchRows();
            
            watch.AddWatchRow(132, "green");
            watch.AddWatchRow(123, "red");
            base.DataContext = watch;
            listWatch.ItemsSource = watch.WatchRows;
           
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            watch.AddWatchRow(132, "pink");
            watch.AddWatchRow(113, "yellow");
           
        }
    }
