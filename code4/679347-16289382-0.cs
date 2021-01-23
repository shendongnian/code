using System.Diagnostics
        Stopwatch sw;
        public Form1()
        {
            InitializeComponent();
            sw = new Stopwatch();
            sw.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = sw.Elapsed.ToString();
        }
