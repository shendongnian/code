    public class MyEventCachingBridge : IDisposable
    {
        CompositeDisposable _disposables;
        public void Dispose()
        {
            _disposables.Dispose();
        }
