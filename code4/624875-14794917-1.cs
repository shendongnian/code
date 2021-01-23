    class DebugLogger
    {
        public DebugLogger(TextBox textBox)
        {
            this.TextBox = textBox;
        }
    
        public TextBox TextBox { get; private set; }
    
        public static DebugLogger Instance { get; set; }
    
        public void Write(string text)
        {
            this.TextBox.Text += text;
        }
    }
