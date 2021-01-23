    public static class TraceHelper
    {
        public static void WriteLine(string message)
        {
    #if MONOTOUCH
            Console.WriteLine(message);//or something else
    #else
            Trace.WriteLine(message);
    #endif
        }
    }
