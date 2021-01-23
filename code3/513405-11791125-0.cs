    public string UserText { get; set;}
    ...
    private void button1_Click(object sender, EventArgs e)
    {
        if (textBox1.Text == "")
        {
            MessageBox.Show("Please enter keyword to search");
        }
        else 
        {
            UserText = textBox1.Text; // set the Text
        }
