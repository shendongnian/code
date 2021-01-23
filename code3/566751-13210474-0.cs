    public partial class MyForm : Form, IMessageFilter {
        private Timer _timer;
        private DateTime _wentIdle;
        public MyForm() {
            // watch for idle events and any message that might break idle
            Application.Idle += new EventHandler(Application_OnIdle);
            Application.AddMessageFilter(this);
            // use a simple timer to watch for the idle state
            _timer = new Timer();
            _timer.Tick += new EventHandler(Timer_Exipred);
            _timer.Interval = 1000;
            _timer.Start();
            InitializeComponent();
        }
        private void Timer_Exipred(object sender, EventArgs e) {
            TimeSpan diff = DateTime.Now - _wentIdle;
            // see if we have been idle longer than our configured value
            if (diff.TotalSeconds >= Settings.Default.IdleTimeout_Sec) {
                _statusLbl.Text = "We Are IDLE! - " + _wentIdle;
            }
        }
        private void Application_OnIdle(object sender, EventArgs e) {
            // keep track of the last time we went idle
            _wentIdle = DateTime.Now;
        }
        public bool PreFilterMessage(ref Message m) {
            // reset our last idle time if the message was user input
            if (isUserInput(m)) {
                _statusLbl.Text = "We Are NOT idle!";
                _wentIdle = DateTime.MaxValue;
            }
            return false;
        }
        private bool isUserInput(Message m) {
            // look for any message that was the result of user input
            if (m.Msg == 0x200) { return true; } // WM_MOUSEMOVE
            if (m.Msg == 0x020A) { return true; } // WM_MOUSEWHEEL
            if (m.Msg == 0x100) { return true; } // WM_KEYDOWN
            if (m.Msg == 0x101) { return true; } // WM_KEYUP
            // ... etc
            return false;
        }
    }
