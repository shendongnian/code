    public class LogEntry: PropertyChangedBase
    {
        public DateTime DateTime { get; set; }
        public int Index { get; set; }
        public string Message { get; set; }
    }
    public class CollapsibleLogEntry: LogEntry
    {
        public List<LogEntry> Contents { get; set; }
    }
