    public partial class Form1 : Form
    {
        Timer loginTimer;
        public Form1()
        {
            InitializeComponent();
        }
        public void InitTimer()
        {
            loginTimer = new Timer();
            loginTimer.Tick += new EventHandler(loginTimer_Tick);
            loginTimer.Interval = 1000;
            loginTimer.Start();
        }
        private void loginTimer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Test!");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InitTimer();
        }
    }
