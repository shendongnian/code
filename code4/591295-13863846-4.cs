    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer tmrStart = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer tmrStop = new System.Windows.Threading.DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            tmrStart.Interval = TimeSpan.FromSeconds(2); //Delay before shown
            tmrStop.Interval = TimeSpan.FromSeconds(3);  //Delay after shown
            tmrStart.Tick += new EventHandler(tmr_Tick);
            tmrStop.Tick += new EventHandler(tmrStop_Tick);
           
        }
        void tmrStop_Tick(object sender, EventArgs e)
        {
            tmrStop.Stop();
            label1.Content = "";
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            tmrStart.Stop();
            label1.Content = "Success";
            tmrStop.Start();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            tmrStart.Start();
        }
        
    }
