    private void Form1_Load(object sender, EventArgs e)
    {
       listBox1.Items.Add("Item1");
       listBox1.Items.Add("Item2");
       listBox1.Items.Add("Item3");
       listBox1.Items.Add("Item4");
     }
            
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
       label1.Text = listBox1.SelectedItem.ToString();   
    }
