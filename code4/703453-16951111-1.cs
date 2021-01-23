    public class DataConsumer : IObserver<int>
    {
        private readonly IDisposable _disposable;
        public DataConsumer(DataAquisitionSimulator das)
        {
            _disposable = das.Subscribe(this);
            _disposable.Dispose();
        }
        public void OnCompleted()
        {
            Console.WriteLine("all done");
        }
        public void OnError(Exception error)
        {
            throw error;
        }
        public void OnNext(int value)
        {
            Console.WriteLine("New data " + value + " at " + DateTime.Now.ToLongTimeString());
        }
    }
