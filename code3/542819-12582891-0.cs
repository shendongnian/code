    public partial class MainWindow : Window
    {
        MyClass _myClassInstance = null;
        public MainWindow()
        {
            InitializeComponent();
            _myClassInstance = new MyClass();
            _myClassInstance.TimedOut += delegate (object sender, EventArgs e) {
                ((MyClass)sender).CancelConnect();
                MessageBox.Show("Timeout!");
            };
            _myClassInstance.ConnectTo();
        }
    }
    
    ...
    
    public class MyClass
    {
        Timer _timer = new Timer();
        public event EventHandler TimedOut;
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnTimedOut();
        }
        private void OnTimedOut()
        {
            var handler = TimedOut;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        public void ConnectTo(int timeout = 2000)
        {
            CancelConnect();
            _timer.Interval = timeout; // pass timeout in so it's flexible
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();
            // do connect stuff...
            _timer.Stop();
        }
        public void CancelConnect()
        {
            _timer.Stop();
        }
    }
