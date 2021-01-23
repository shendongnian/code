    using System.Windows;
    using System.Windows.Threading;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            private DispatcherTimer timer;
        
            public MainWindow()
            {
                InitializeComponent();
    
                this.timer = new DispatcherTimer();
                this.timer.Tick += timer_Tick;
                this.timer.Interval = new System.TimeSpan(0, 0, 1);
                this.timer.Start();
            }
    
            private void timer_Tick(object sender, System.EventArgs e)
            {
                this.pb.Value = System.DateTime.Now.Second % 100;
            }
        }
    }
