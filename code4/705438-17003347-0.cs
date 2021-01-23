        using (StreamWriter _logFile = File.CreateText(_logFileName))
        {
            using (var builder = new StringBuildingStreamWriter(_logFile)) 
            {
                builder.WriteLine("Logfile name is: " + _logFileName);
                builder.WriteLine("LOG FILE STARTED AT: " + _startDateTime.ToString());
                builder.WriteLine("============================================");
                builder.Write(_message);
                builder.WriteLine();
                content += builder.ToString();
            }            
            _logFile.Close();
        }
    
    public class StringBuildingStreamWriter:TextWriter
    {
        StringBuilder sb = new StringBuilder();
        private StreamWriter sw;
        public StringBuildingStreamWriter(StreamWriter sw)
        {
            this.sw = sw;
        }
        public override void WriteLine(string value)
        {
            sb.AppendLine(value);
            sw.WriteLine(value);
        }
        
        public override void WriteLine()
        {
            sw.WriteLine();
            sb.AppendLine();
        }
        public override void Write(string value)
        {
            sb.Append(value);
            sw.Write(value);
        }
        public override string ToString()
        {
            return sb.ToString();
        }
        public override Encoding Encoding
        {
            get { return UTF8Encoding.UTF8; }
        }
    }
