    internal static class SqlProcessorHelper {
        public void StreamSetup(Stream toSetUp) {
            // Shared code to prepare the stream
        }
    }
    public class SqlServerProcessor : IDatabaseProcessor {
        void ProcessData(Stream stream) {
            SqlProcessorHelper.StreamSetup(stream);
        }
    }
    public class DB2Processor : IDatabaseProcessor {
        void ProcessData(Stream stream) {
            SqlProcessorHelper.StreamSetup(stream);
        }
    }
