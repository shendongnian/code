    public class CompositeDisposable : IDisposable
    {
        private IDisposable[] _disposables;
        public CompositeDisposable(params IDisposable[] disposables)
        {
            _disposables = disposables;
        }
        public void Dispose()
        {
            if(_disposables == null)
            {
                return;
            }
            foreach(var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
