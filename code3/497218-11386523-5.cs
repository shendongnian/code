     public Form2()
        {
            InitializeComponent();
            listBox1.Items.Add("Arial");
            listBox1.Items.Add("Calibri");
            listBox1.Items.Add("Times New Roman");
            listBox1.Items.Add("Verdana");
            listBox2.Items.Add("8");
            listBox2.Items.Add("10");
            listBox2.Items.Add("12");
            listBox2.Items.Add("14");
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
        textBox1.Text = "hello";       
        textBox1.Font = new Font(listBox1.SelectedItem.ToString(), Convert.ToInt32(listBox2.SelectedItem.ToString()));  
        }
