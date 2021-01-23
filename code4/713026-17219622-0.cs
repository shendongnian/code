    private Boolean _backspace = false;
    
    private void textBox1_KeyDown(Object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back)
        {
            e.SuppressKeyPress = _backspace;
            e.Handled = _backspace;
            _backspace = true;
        }
    }
    
    private void textBox1_KeyUp(Object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Back)
            _backspace = false;
    }
