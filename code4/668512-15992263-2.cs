    public interface ICancellable
    {
        bool CancellationPending {get;}
    }
    public class BackgroundWorkerWrapper : ICancellable
    {
        private BackgroundWorker _realWorker;
        public BackgroundWorkerWrapper(BackgroundWorker realWorker)
        {
            _realWorker = realWorker;
        }
        public bool CancellationPending 
        {
            get { return _realWorker.CancellationPending; }
        }
    }
