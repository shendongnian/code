    public class MyTextWriterTraceListener : TextWriterTraceListener
    {
        public MyTextWriterTraceListener(string logFileName)
            : base(logFileName)
        {
            base.Writer = new StreamWriter(logFileName, false);
        }
    }
