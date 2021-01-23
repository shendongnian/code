    public delegate void TraceWriterHandler(string message);
    internal class SynchronizedTraceListener : TraceListener
    {
        private TraceWriterHandler messageHandler;
        public SynchronizedTraceListener(TraceWriterHandler writeHandler)
        {
            messageHandler = writeHandler;
        }
        public override void Write(string message)
        {
            messageHandler(message);
        }
        public override void WriteLine(string message)
        {
            messageHandler(message + System.Environment.NewLine);
        }
    }
