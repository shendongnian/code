    public class EnhancedTextBox : TextBox
    {
        private Boolean _backspace = false;
        public EnhancedTextBox() 
        {
            KeyDown += new KeyEventHandler(EnhancedTextBox_KeyDown);
            KeyUp += new KeyEventHandler(EnhancedTextBox_KeyUp);
        }
        void EnhancedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                _backspace = false;
        }
        void EnhancedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = _backspace;
                e.Handled = _backspace;
                _backspace = true;
            }
        }
    }
