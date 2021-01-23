     public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(){Interval = new TimeSpan(0,0,0,1)};
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e) {
            Checking();
        }
        public void Checking()
        {   
           .....
        }
