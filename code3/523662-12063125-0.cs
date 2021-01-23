    internal class DataProcessor
    {
        public void Do(Stream stream) 
        {
            // common processing here
        }
    }
    public class SqlServerProcessor : IDatabaseProcessor
    {
        void ProcessData(Stream stream)
        {
            new DataProcessor().Do(stream);
        }
    }
    public class DB2Processor : IDatabaseProcessor
    {
        void ProcessData(Stream stream)
        {
            new DataProcessor().Do(stream);
        }
    }
