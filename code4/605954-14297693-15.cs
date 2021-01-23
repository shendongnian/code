    void Main()
    {
        var scheduler = Scheduler.Default;
        var rnd = new Random();
        var canceller = new CancellationTokenSource();
        
        var source = new MyCustomDataSource();    
        var eventRelayInterval = 2000;
        var bridge = new MyEventCachingBridge(source, eventRelayInterval, scheduler);
    
        var window = new BridgeConsumer(bridge);
        window.Closed += (o,e) => { canceller.Cancel(); window.Dispose(); };
        window.Show();
    
        Task.Factory.StartNew(
            () => 
            {
                while(true)
                {
                    var thing = new Thing() 
                    { 
                        Key = "added thing " + rnd.Next(0, 100), 
                        Title = "title for added thing", 
                        TimeStamp = scheduler.Now.DateTime 
                    };
                    source.FireAdd(thing);
                    Thread.Sleep(rnd.Next(1,10) * 100);
                }
            }, canceller.Token);            
    }
    
    public class BridgeConsumer : Window, IDisposable
    {
        private readonly CompositeDisposable _disposables;
        private StackPanel _panel;
    
        public void OnLoaded(object sender, RoutedEventArgs ea)
        {
            _panel = new StackPanel();
            this.Content = _panel;
        }
        
        public BridgeConsumer(MyEventCachingBridge bridge)
        {
            _disposables = new CompositeDisposable();
            _disposables.Add(bridge);
            
            Loaded += OnLoaded;
            
            var bulkStart = Observable.FromEvent(
                    h => bridge.BulkChangesStart += new EventDelegateBulkChangesStart(h),
                    h => bridge.BulkChangesStart -= new EventDelegateBulkChangesStart(h));
            var bulkEnd = Observable.FromEvent(
                    h => bridge.BulkChangesEnd += new EventDelegateBulkChangesEnd(h),
                    h => bridge.BulkChangesEnd -= new EventDelegateBulkChangesEnd(h));
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
                
            Action<Thing, string> addToList = (thing, msg) => 
            {
                var text = new TextBlock() 
                { 
                    Text = string.Format(
                        "At:{0} Key:{1} Msg:{2}", 
                        thing.TimeStamp, 
                        thing.Key, 
                        msg) 
                };
                _panel.Children.Add(text);
            };
            
            _disposables.Add(bridgeWatcher.ObserveOnDispatcher().Subscribe(tup => 
                {
                    addToList(tup.Item2, tup.Item1);
                }));
        }
    
        public void Dispose()
        {
            if(_disposables != null) _disposables.Dispose();
        }
    }
    
    
    public delegate void EventDelegateAdd(Thing thing);
    public delegate void EventDelegateChange(Thing thing);
    public delegate void EventDelegateRemove(Thing thing);
    
    public delegate void EventDelegateBulkChangesStart();
    public delegate void EventDelegateBulkChangesEnd();
    
    // The "Things" that are stored in MyCustomDataSource
    
    public class Thing
    {
        public DateTime TimeStamp {get; set;}
        public string Key { get; set; }
        public string Title { get; set; }
        public object OtherStuff { get; set; }
        public override string ToString()
        {
            return string.Format("At:{0} Key:{1} Title:{2}", this.TimeStamp, this.Key, this.Title);        
        }
    }
    
    // A custom observable data source with events that indicate when Things are
    // added, changed, or removed.
    
    public class MyCustomDataSource
    {
        public event EventDelegateAdd AddingThing = delegate { };
        public event EventDelegateChange ChangingThing = delegate { };
        public event EventDelegateRemove RemovingThing = delegate { };
    
        // The rest of the class that manages the database of Things...
        public void FireAdd(Thing toAdd)
        {
            AddingThing(toAdd);
        }
        public void FireChange(Thing toChange)
        {
            ChangingThing(toChange);
        }
        public void FireRemove(Thing toRemove)
        {
            RemovingThing(toRemove);
        }
    }
    
    // This class forms a configurable event bridge between the MyCustomDataSource and
    // the GUI.  The goal is to cache, filter, and throttle the events so that the GUI
    // updates only occasionally with bulk changes that are relevant for that control.
    
    public class MyEventCachingBridge : IDisposable
    {
        private enum ThingEventType
        {
            Add,
            Change,
            Remove
        }
    
        private MyCustomDataSource mSource;
        private IScheduler _scheduler;
    
        public event EventDelegateBulkChangesStart BulkChangesStart = delegate { };
        public event EventDelegateBulkChangesEnd BulkChangesEnd = delegate { };
    
        public IObservable<Thing> RawAdds {get; private set;}
        public IObservable<Thing> RawChanges {get; private set;}
        public IObservable<Thing> RawRemoves {get; private set;}
    
        public Subject<Thing> BufferedAdds {get; private set;}
        public Subject<Thing> BufferedChanges {get; private set;}
        public Subject<Thing> BufferedRemoves {get; private set;}
    
        private readonly IObservable<IList<Tuple<Thing,ThingEventType>>> _buffer;
        private List<IList<Tuple<Thing,ThingEventType>>> _eventQueue;
        private static object SyncRoot = new object();
        
        private readonly CompositeDisposable _disposables;
        private readonly SerialDisposable _watcherDisposable;
    
        public MyEventCachingBridge(MyCustomDataSource source, int eventRelayInterval, IScheduler scheduler)
        {
            _disposables = new CompositeDisposable();
            mSource = source;
            _scheduler = scheduler;
            _eventQueue = new List<IList<Tuple<Thing,ThingEventType>>>();
            
            // Magical Reactive Extensions code goes here that subscribes to all 3 events...
            //
            //   mSource.AddingThing
            //   mSource.ChangingThing
            //   mSource.RemovingThing
            // 
            //  ...filters and records a list of the events as they are received ( maintaining order of events too ),
            //  then every eventRelayInterval milliseconds, plays back the events in bulk to update the GUI 
            //  ( on the GUIs thread ).  Note that LINQ will be used to filter the Things so that a subset of
            //  Thing changes are relayed to the GUI - i.e. - not all Thing events are observed by the GUI.
            RawAdds = Observable.FromEvent<EventDelegateAdd, Thing>(
                ev => new EventDelegateAdd(ev),
                h => mSource.AddingThing += h,
                h => mSource.AddingThing -= h);
            BufferedAdds = new Subject<Thing>();
    
            RawChanges = Observable.FromEvent<EventDelegateChange, Thing>(
                ev => new EventDelegateChange(ev),
                h => mSource.ChangingThing += h,
                h => mSource.ChangingThing -= h);
            BufferedChanges = new Subject<Thing>();
    
            RawRemoves = Observable.FromEvent<EventDelegateRemove, Thing>(
                ev => new EventDelegateRemove(ev),
                h => mSource.RemovingThing += h,
                h => mSource.RemovingThing -= h);
            BufferedRemoves = new Subject<Thing>();
    
            _buffer = Observable.Merge(
                        _scheduler,
                        RawAdds.Select(e => Tuple.Create(e, ThingEventType.Add)), 
                        RawChanges.Select(e => Tuple.Create(e, ThingEventType.Change)), 
                        RawRemoves.Select(e => Tuple.Create(e, ThingEventType.Remove)))
                .Buffer(TimeSpan.FromMilliseconds(eventRelayInterval), _scheduler);
    
            _watcherDisposable = new SerialDisposable();
            _watcherDisposable.Disposable = _buffer
                .ObserveOn(_scheduler)
                .Subscribe(batch => 
                { 
                    lock(SyncRoot) { _eventQueue.Add(batch); }
                });
            _disposables.Add(_watcherDisposable);
            
            var pulse = Observable.Interval(TimeSpan.FromMilliseconds(eventRelayInterval), _scheduler);
            _disposables.Add(pulse.ObserveOn(_scheduler).Subscribe(x => PlayBackCachedEvents()));
        }
    
        private void PlayBackCachedEvents()
        {
            BulkChangesStart();   // Raise Event to notify GUI to suspend screen updates
    
            try
            {            
                //_eventQueue.Dump();
                lock(SyncRoot)
                {
                    foreach(var batch in _eventQueue)
                    {
                        // Play back the list of events to push changes to ListView, TreeView, graphs, etc...            
                        foreach(var evt in batch)
                        {
                            switch(evt.Item2)
                            {
                                case ThingEventType.Add: BufferedAdds.OnNext(evt.Item1); break;
                                case ThingEventType.Change: BufferedChanges.OnNext(evt.Item1);break;
                                case ThingEventType.Remove: BufferedRemoves.OnNext(evt.Item1);break;
                            }
                        }
                    }
                    _eventQueue.Clear();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception during playback:" + ex);
            }
            BulkChangesEnd();   // Raise Event to notify GUI to allow control refresh
        }
    
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
