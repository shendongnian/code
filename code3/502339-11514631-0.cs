    public class Logger
    {
        public Logger(TextWriter writer)
        {
            _writer = writer;
        }
        private TextWriter _writer;    
    
        public void Write(string text)
        {
            _writer.Write(text);
        }
    }
