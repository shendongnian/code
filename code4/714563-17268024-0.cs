    private void button1_Click(object sender, EventArgs e)
    {
        StreamWriter Info = File.AppendText("Contacts.txt");
        for (int i = 0; i < 1; i++) //WHY?!  You don't need a loop if you're only doing something one time.
        {
            listBox1.Items.Add(textBox1.Text);
            listBox1.Items.Add(textBox2.Text);
        }
    }
