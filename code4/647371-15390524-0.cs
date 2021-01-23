    public class TextBoxWriter : TextWriter
    {
        TextBox _textBox = null;
        
        public TextBoxWriter(TextBox textBox)
        {
            _textBox = textBox;
        }
    
        public override void WriteLine(string message)
        {
            base.Write(message);
            _textBox.AppendText(message); 
        }
    
        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }
