    private void urlTextBox_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Return)
        {                
            e.SuppressKeyPress = true;
        }
    }
    private void urlTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Return)
        {
            e.Handled = true;
            goButton.PerformClick();
        }
    }
