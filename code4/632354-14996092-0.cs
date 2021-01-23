    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        UpdateTextBox();
    }
    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        UpdateTextBox();
    }
    void UpdateTextBox()
    {
        var words = new List<string>();
        if (checkbox1.Checked)
            words.Add("Example 1");
        if (checkbox2.Checked)
            words.Add("Example 2");
        textBox1.Text = string.Join(" ", words);
    }
