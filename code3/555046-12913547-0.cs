    public partial class MainWindow : Window
    {
        DispatcherTimer dt;
        public MainWindow()
        {
            InitializeComponent();
            dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 5);//wait for 5 Seconds
            dt.Tick += new EventHandler(dt_Tick);
        }
        void dt_Tick(object sender, EventArgs e)
        {
            //do code
        }
        private void button1_MouseEnter(object sender, MouseEventArgs e)
        {
            dt.Start();
        }
        private void button1_MouseLeave(object sender, MouseEventArgs e)
        {
            dt.Stop();
        }
    }
