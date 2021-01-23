        public Form1()
        {
            InitializeComponent();
            foreach(var b in Controls.OfType<Button>())
                b.Click += new EventHandler(AnyButton_Click);
        }
        void AnyButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("all");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("3");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2");
        }
