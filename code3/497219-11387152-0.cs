        public Form1()
        { 
            InitializeComponent();
            //populate listbox1 
            listBox1.Items.Add("Arial"); 
            listBox1.Items.Add("Calibri"); 
            listBox1.Items.Add("Times New Roman"); 
            listBox1.Items.Add("Verdana");
            listBox1.SelectedIndex = 0; // <--- set default selection for listBox1
            //populate listbox2
            listBox2.Items.Add("8"); 
            listBox2.Items.Add("10"); 
            listBox2.Items.Add("12"); 
            listBox2.Items.Add("14");
            listBox2.SelectedIndex = 0; // <--- set default selection for listBox2
        } 
 
        private void button1_Click(object sender, EventArgs e) 
        { 
            textBox1.Text = "hello";        
            textBox1.Font = new Font(listBox1.SelectedItem.ToString(), Convert.ToInt32(listBox2.SelectedItem.ToString()));   
        } 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        } 
    }
}
