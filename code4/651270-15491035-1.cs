    public partial class Form1 : Form
    {
        private static Timer _timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            _timer.Tick += _timer_Tick;
            _timer.Interval = 5000; // 5 seconds
            _timer.Start();            
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            // Exit the App here ....
            Application.Exit();
        }
    }
