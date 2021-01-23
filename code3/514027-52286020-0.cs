    private void input_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            // Your logic here....
            e.Handled = true; //Handle the Keypress event (suppress the Beep)
        }
    }
