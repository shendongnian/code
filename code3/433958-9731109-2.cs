    public class ClassThatUsesLogger
    {
        private ILogger Logger { get; set; }
        public ClassThatUsesLogger(ILogger logger) { Logger = logger }
    }
