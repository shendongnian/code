    class ObservableDevice : IConnectableObservable
    {
        public ObservableDevice(IDevice device)
        {
            _device = device;
            //not strictly necessary to cache this, but this way you only
            //create it once
            _stream = Observable.FromEvent<...>(...);
        }
        private IDevice _device;
        private IObservable _stream;
        public IDisposable Connect()
        {
            //it's up to you if you want/need to guard against multiple starts
            _device.Start();
            return Disposable.Create(() => { _device.Stop(); });
        }
        public IDisposable Subscribe(IObserver observer)
        {
            //error checking if you want, or just defer to 
            //_stream.Subscribe's error checking
            return _stream.Subscribe(observer);
        }
    }
