    public class LoggerOptions
    {
        public LoggerOptions Debug() { LoggerType = LoggerType.Debug; return this; }
        public LoggerOptions Error() { LoggerType = LoggerType.Error; return this; }
        public LoggerOptions Message(string message) { ...; return this; }
        public LoggerType Type { get; set; }
        ...
    }
