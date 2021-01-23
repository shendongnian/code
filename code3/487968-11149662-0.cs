    class NewClass 
    { 
        private Subject<UsefulInfo> _subject = new Subject<UsefulInfo>(); 
        private IDictionary<string, IObservable<UsefulInfo>> _keyedObservables; 
     
        public NewClass() 
        { 
            _keyedObservables = new Dictionary<string, IObservable<UsefulInfo>>();
        } 
     
        IDisposable Subscribe(string key, Action<UsefulInfo> callback) 
        { 
            // NOT threadsafe for concurrent subscriptions!
            if (!_keyedObservables.Contains(key))
            {
                var keyedAndPublished = _subject.Where(x => x.Key == key)
                    .Publish()
                    .RefCount();
                _keyedObservables.Add(key, keyedAndPublished);
            }
            return _keyedObservables[key].Subscribe(callback);
        } 
     
        // Some event happens that we want to notify subscribers about 
        void EventHandler(object sender, SomeEventArgs e) 
        { 
            UsefulInfo info = CreateUsefulInfo(e); 
     
            _observable.OnNext(info); 
        } 
    } 
