    private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            foreach (string s in listBox1.SelectedItems)
            {
                this.richTextBox1.AppendText(s + Environment.NewLine);
            }
            e.Handled = true;
        }
    }
