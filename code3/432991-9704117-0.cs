    //Basic processor interface
    public interface IExecutionProvider
    {
        void ProcessFile(string file);
    }
    //Simplified version of one of the custom processor interfaces
    public interface IKyoExecutionProcessor
    {
        string DestinationPath { get; set; }
    }
    public class KyoExecutionProcessor : IExecutionProvider, IKyoExecutionProcessor
    {
        //This processor moves a file to the DestinationPath.
        public string DestinationPath { get; set; }
        public void ProcessFile(string file) { }
    }
    public interface IFileQueueService<TProvider>
        where TProvider : IExecutionProvider
    {
        string SourcePath { get; set; }
        TProvider ExecutionProvider { get; set; }
        void Start();
        void Stop();
    }
    public class FileProcessor<TProvider> : IFileQueueService<TProvider>
        where TProvider : IExecutionProvider
    {
        string[] GetFilesReadyToProcess() { return new string[0]; }
        public TProvider ExecutionProvider { get; set; }
        public virtual void ProcessFileQueue()
        {
            IEnumerable<string> filesToProcess = GetFilesReadyToProcess();
            foreach (string file in filesToProcess.ToList())
            {
                ExecutionProvider.ProcessFile(file);
            }
        }
        #region IFileQueueService<TProvider> Members
        public string SourcePath { get; set; }
        public void Start() { }
        public void Stop() { }
        #endregion
    }
    public class KYOFileSysWatcher : ServiceBase
    {
        private IFileQueueService<KyoExecutionProcessor> Processor { get; set; }
        private KyoExecutionProcessor KyoCustomProcessor { get; set; }
        public KYOFileSysWatcher()
        {
            Processor = ObjectFactory.GetInstance<IFileQueueService<KyoExecutionProcessor>>();
            KyoCustomProcessor = ObjectFactory.GetInstance<KyoExecutionProcessor>();
            //This compiles now !!
            Processor.ExecutionProvider = KyoCustomProcessor;
            Processor.Start(); //Sets up dispatch timer
        }
    }
