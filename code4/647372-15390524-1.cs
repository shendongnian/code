    public class TextBoxWriter : TextWriter
    {
        TextBox _textBox = null;
        
        public TextBoxWriter(TextBox textBox)
        {
            _textBox = textBox;
        }
        private void AppendText(string message) 
        {
            _textBox.AppendText(message);
            _textBox.AppendText(Environment.NewLine);
        }
    
        public override void Write(string message)
        {
            base.Write(message);
            if (_textBox.InvokeRequired) 
                _textBox.Invoke(new Action<string>((msg) => AppendText(msg)), message);
            else 
                AppendText(message);
        }
    
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
