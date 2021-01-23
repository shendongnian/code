    private void button1_Click(object sender, EventArgs e)
    {
        int total = myAdd.Add(int.Parse(textBox1.Text), int.Parse(textBox2.Text));    
        MessageBox.Show(total.ToString());
    }
