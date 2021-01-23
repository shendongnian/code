        public class TextBoxWriter : TextWriter
        {
            TextBox _output = null;
    
            public TextBoxWriter (TextBox output)
            {
                _output = output;
            }
    
            public override void Write(char value)
            {
                base.Write(value);
                _output.AppendText(value.ToString());
            }
    
            public override Encoding Encoding
            {
                get { return System.Text.Encoding.UTF8; }
            }
        }
