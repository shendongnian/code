    class LoggingTextWriter : TextWriter 
    {
        private const string LogFilePath = @"C:\your_log_file.txt";
        
        public override void Write(char[] buffer, int index, int count) 
        {
            Write(new String(buffer, index, count));
        }
        public override void Write(string value) 
        {
            File.AppendAllText(LogFilePath, DateTime.Now + value);
        }
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
    }
