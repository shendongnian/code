    private void button1_Click(object sender, EventArgs e)
    {
        StreamWriter Info = File.AppendText("Contacts.txt");
        
        string textbox1Content = textbox1.Text;
        string textbox1Content = textbox2.Text;
        
        listBox1.Items.Add(textbox1Content);
        listBox1.Items.Add(textbox1Content);
        textBox1.Text = String.Empty;
        textBox2.Text = String.Empty;
    }
