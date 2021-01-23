    private TextBox focusedControl;
    private void TextBox_GotFocus(object sender, EventArgs e)
    {
        focusedControl = (TextBox)sender;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (focusedControl != null)
        {   
            focusedControl.Text  += "1";
        }
    }
