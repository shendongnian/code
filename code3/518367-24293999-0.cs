    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (textBox1.Text.Length > 0)
        {
            ToolTipService.SetIsEnabled(textBox1, true);
        }
    }
