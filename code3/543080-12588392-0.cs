    class Program
    {
        static TraceSource ts = new TraceSource("myTraceSource");
        static void Main(string[] args)
        {
            ts.TraceEvent(TraceEventType.Verbose, 0, "Hello");
        }
    }
