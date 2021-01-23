      private void button1_Click(object sender, EventArgs e)
    {
        listBox1.Items.Add(textBox1.Text);
        listBox1.Items.Add(textBox2.Text);
        listBox1.Items.Add(Environment.NewLine);
        textBox1.Clear();
        textBox2.Clear();
    }
