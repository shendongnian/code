    public interface IDatabaseProcessor {
       void ProcessData(Stream stream);
    }
    public abstract class AbstractDatabaseProcessor : IDatabaseProcessor {
        public void ProcessData(Stream stream) {
          // setting up logic to read the stream is not duplicated
        }
    }
    public class SqlServerProcessor : AbstractDatabaseProcessor {
        //SqlServerProcessor specific methods go here
    }
    public class DB2Processor : AbstractDatabaseProcessor {
        // DB2Processor specific methods go here
    }
    public class NonSharedDbProcessor : IDatabaseProcessor {
        void ProcessData(Stream stream) {
          // set up logic that is different than that of AbstractDatabaseProcessor
        }
    }
