    public class BridgeConsumer : Window, IDisposable
    {
        private readonly CompositeDisposable _disposables;
        private IScheduler _scheduler;
        private StackPanel _panel;
    
        public void OnLoaded(object sender, RoutedEventArgs ea)
        {
            _panel = new StackPanel();
            this.Content = _panel;
        }
        
        public BridgeConsumer(MyEventCachingBridge bridge, IScheduler scheduler)
        {
            // for cleanup of any subscriptions
            _disposables = new CompositeDisposable();
            _disposables.Add(bridge);
            _scheduler = scheduler;
            
            Loaded += OnLoaded;
            
            // setup a listener for the bulk start/end events on the bridge
            var bulkStart = Observable.FromEvent(
                    h => bridge.BulkChangesStart += new EventDelegateBulkChangesStart(h),
                    h => bridge.BulkChangesStart -= new EventDelegateBulkChangesStart(h));
            var bulkEnd = Observable.FromEvent(
                    h => bridge.BulkChangesEnd += new EventDelegateBulkChangesEnd(h),
                    h => bridge.BulkChangesEnd -= new EventDelegateBulkChangesEnd(h));
    
            // the "meaty bit" - 
            //    1. create a "window" defined by bulk start/end events
            //    2. inside that "window", trap any occurrences on a 
            //          merged view of adds/changes/removes
            //    3. foreach event in that window, select that event
            //         (i.e., give us window contents as a stream of sorts)
            var bridgeWatcher =
                from thingEventWindow in 
                    Observable.Merge(
                        bridge.BufferedAdds.Select(t => Tuple.Create("add", t)), 
                        bridge.BufferedChanges.Select(t => Tuple.Create("change", t)), 
                        bridge.BufferedRemoves.Select(t => Tuple.Create("remove", t))
                    )
                    .Window(bulkStart, start => bulkEnd)
                from thingEvent in thingEventWindow
                select thingEvent;
                
            // this could just as easily be a method, a bound call to the viewmodel, etc
            Action<Thing, string, DateTimeOffset> addToList = (thing, msg, ts) => 
            {
                var text = new TextBlock() 
                { 
                    Text = string.Format(
                        "At:{0} Key:{2} Msg:{3} - nowTime = {1}", 
                        thing.TimeStamp, 
                        ts, 
                        thing.Key, 
                        msg) };
                _panel.Children.Add(text);
            };
            
            _disposables.Add(bridgeWatcher
                // CAREFUL! "ObserveOn" means what you'd think "SubscribeOn" would
                .ObserveOnDispatcher()
                .Subscribe(tup => 
                {
                    addToList(tup.Item2, tup.Item1, _scheduler.Now);
                }));
        }
    
        public void Dispose()
        {
            // clean up
            if(_disposables != null) _disposables.Dispose();
        }
    }
