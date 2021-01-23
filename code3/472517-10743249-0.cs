    public class Log
    {
        private StreamWriter output;
        public Log()
        {
            output = new StreamWriter(File.OpenWrite("output.txt"));
    
        }
        public void Write(char c)
        {
            lock (output)
            {
                output.Write(c);
            }
        }
        public void Close()
        {
            output.Close();
        }
    }
    
    public class MyConsoleOutput : TextWriter
    {
        private TextWriter standard;
        private Log log;
    
        public MyConsoleOutput(TextWriter standard, Log log)
        {
            this.standard = standard;
            this.log = log;
        }
    
        public override void Write(char value)
        {
            standard.Write(value);
            log.Write(value);
        }
    
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
    
        protected override void Dispose(bool disposing)
        {
            standard.Dispose();
        }
    }
    
    public class MyConsoleInput : TextReader
    {
        private TextReader standard;
        private Log log;
        public MyConsoleInput(TextReader standard, Log log)
        {
            this.standard = standard;
            this.log = log;
        }
    
        public override int Peek()
        {
            return standard.Peek();
        }
    
    
        public override int Read()
        {
            int result = standard.Read();
            log.Write((char)result);
            return result;
        }
        protected override void Dispose(bool disposing)
        {
            standard.Dispose();
        }
    }
