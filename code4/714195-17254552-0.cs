    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        int _ta = 0;
        public Form1()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (_ta < 1)
            {
                _ta++;
                System.Diagnostics.Debug.WriteLine("This should only be called once...");
                System.Diagnostics.Debug.WriteLine(_ta);
            }
            System.Diagnostics.Debug.WriteLine("This should be called every tick...");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }
    }
