    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer oneShot = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            oneShot.Interval = new TimeSpan(0, 0, 0, 0, 100);
            oneShot.Tick += new EventHandler(oneShot_Tick);
        }
        void oneShot_Tick(object sender, EventArgs e)
        {
            oneShot.Stop();
            // Your Code or Method here
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            oneShot.Start();
        }
    }
