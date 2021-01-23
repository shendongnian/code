    public class DummyFactory : ITraceOutputFactory
    {
        public TextWriter Create(string outputFile)
        {
            return new StringWriter();
        }
    }
