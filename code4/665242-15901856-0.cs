        bool showtext = false;
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = showtext;
            button1.Click += button1_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            showtext = !showtext;
            textBox1.Visible = showtext;
        }
