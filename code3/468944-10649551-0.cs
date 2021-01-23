        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click); 
            //add above line
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here's a message??");
        }
