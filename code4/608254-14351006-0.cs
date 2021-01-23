    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var textbox = sender as TextBox;
        if (string.IsNullOrEmpty(textbox.Text))
        {
            btn_cancel.Visible = false;
        }
        else
        {
            btn_cancel.Visible = true;
        }
    }
