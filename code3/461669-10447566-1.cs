    public partial class MainWindow : Window
    {
        private Timer _timer;
        private int _time;
        public MainWindow()
        {
            InitializeComponent();
            _time = 0;
            _timer = new Timer(1000);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        }
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            Dispatcher.Invoke(new Action(() =>
                                             {
                                                 _time++;
                                                 tbTime.Text = _time.ToString();
                                             }));
        }
        private void btnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }
            else
            {
                _timer.Start();
            }
        }
    }
