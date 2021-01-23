    public static class TraceSources
    {
        public static TraceSource Create(string sourceName)
        {
            var source = new TraceSource(sourceName);
            source.Listeners.AddRange(Trace.Listeners);
            source.Switch.Level = SourceLevels.All;
            return source;
        }
    }
    public class Class1
    {
        private static readonly Lazy<TraceSource> trace = new 
                Lazy<TraceSource>(() => TraceSources.Create("Class1"));
        public void DoSomething()
        {
            trace.Value.TraceEvent(TraceEventType.Information, 1, "Class1 speaking up");
        }
    }
    public class Class2
    {
        private static readonly Lazy<TraceSource> trace = new
                Lazy<TraceSource>(() => TraceSources.Create("Class2"));
        public void DoSomethingElse()
        {
            trace.Value.TraceEvent(TraceEventType.Information, 2, "Class2 speaking out");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var listener = new TextWriterTraceListener(@"C:\trace.txt");
                Trace.Listeners.Add(listener);
                var classOne = new Class1();
                var classTwo = new Class2();
                classOne.DoSomething();
                classTwo.DoSomethingElse();
            }
            finally
            {
                Trace.Close();
            }
        }
    }
