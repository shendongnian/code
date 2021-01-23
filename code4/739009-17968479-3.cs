    public class DummyFactory : ITraceOutputFactory
    {
        public TextWriter Create(string outputFile)
        {
            return TextWriter.Null;
        }
    }
