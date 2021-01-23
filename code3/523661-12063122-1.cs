    public interface IDatabaseProcessor
    {
       void ProcessData(Stream stream);
    }
    public abstract class AbstractDatabaseProcessor : IDatabaseProcessor
    {
        public virtual void ProcessData(Stream stream)
        {
          // setting up logic to read the stream is duplicated code
        }
    }
    public class SqlServerProcessor : AbstractDatabaseProcessor
    {
        public void ProcessData(Stream stream)
        {
            base.ProcessData(stream);
            
            // Sql specific processing code
        }
    }
    public class DB2Processor : AbstractDatabaseProcessor
    {
        public void ProcessData(Stream stream)
        {
            base.ProcessData(stream);
            
            // DB2 specific processing code
        }
    }
