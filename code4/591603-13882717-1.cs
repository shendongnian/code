    public partial class MainPage : PhoneApplicationPage
    {
        private DispatcherTimer _timer;
        private int _countdown;
    
        // Constructor
        public MainPage()
        {
            InitializeComponent();
    
            _countdown = 100;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) => Tick();
            _timer.Start();
        }
    
        private void Tick()
        {
            _countdown--;
    
            if (_countdown == 0)
            {
                _timer.Stop();
            }
    
            countText.Text = _countdown.ToString();
        }
    }
