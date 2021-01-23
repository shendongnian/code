    // Error checking elided for expository purposes.
    public interface IProgressReporter 
    {
        void ReportProgress(int progress, object status);
    }
    public class BackgroundWorkerProgressReporter : IProgressReporter
    {
        private BackgroundWorker _worker;
        public BackgroundWorkerProgressReporter(BackgroundWorker worker)
        {
            _worker = worker;
        }
        public void ReportProgress(int progress, object status)
        {
            _worker.ReportProgress(progress, status);
        }
    }
