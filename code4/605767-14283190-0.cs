        // Global string list
        List<string> inputList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 0)
            {
                MessageBox.Show("empty");
            }
            else if (textBox1.Text.Length > 20)
            {
                MessageBox.Show("Too many letters");
            }
            else
            {
                // Add to list if less than 20 but greater than 0
                inputList.Add(textBox1.Text);
            }
        }
