    private void button_Click(object sender, EventArgs e)
    {
        if (textbox.Text.Length > 0)
        {
            textbox.Text = textbox.Text.Remove(textbox.Text.Length - 1);
        }
    }
