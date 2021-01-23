    private void button1_Click(object sender, EventArgs e)
    {
        if (letters.CaseSensitiveContainsAny(textBox1.Text))
        {
            MessageBox.Show("Your word contains a or e.");
        }
    }
    
