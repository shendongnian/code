    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Click!");
    }
    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            button1_Click(textBox1, new EventArgs());
    }
