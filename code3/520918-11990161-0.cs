    public class LogLine
    {
        public string Message { get; set; }
        public Color Color { get; set; }
        public DateTime TimeStamp { get; set; }
    }
     List<LogLine> _log = new List<LogLine>(5000);
