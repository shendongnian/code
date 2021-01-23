    private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            richTextBox2.Text = richTextBox1.Text;
        }
    }
