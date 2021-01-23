    public interface IDatabaseProcessor
    {
       void ProcessData(Stream stream);
    }
    public abstract class DatabaseProcessor : IDatabaseProcessor
    {
        public void ProcessData(Stream stream)
        {
          // setting up logic to read the stream is duplicated code
        }
    }
    public class SqlServerProcessor : DatabaseProcessor
    {
        public void ProcessData(Stream stream)
        {
          base.ProcessData(stream);
        }
    }
    public class DB2Processor: DatabaseProcessor
    {
        public void ProcessData(Stream stream)
        {
         base.ProcessData(stream);
        }
    }
