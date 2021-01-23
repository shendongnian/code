    private void richTextBox1_SelectionChanged(object sender, EventArgs e)
    {
        int index = richTextBox1.SelectionStart;
        int line = richTextBox1.GetLineFromCharIndex(index);
        label1.Text = "cursor at line " + line.ToString();
    }
