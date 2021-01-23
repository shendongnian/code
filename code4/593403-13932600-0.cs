        public Form1()
        {
            InitializeComponent();
            button1.KeyDown += new KeyEventHandler(button1_down);
            button1.MouseDown+=new MouseEventHandler(button1_down);
            button1.KeyUp += new KeyEventHandler(button1_Up);
            button1.MouseUp += new MouseEventHandler(button1_Up);
        }
        void button1_down(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
        }
        private void button1_Up(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
        }
