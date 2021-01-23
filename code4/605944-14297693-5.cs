    public delegate void EventDelegateAdd(Thing thing);
    public delegate void EventDelegateChange(Thing thing);
    public delegate void EventDelegateRemove(Thing thing);
    
    public delegate void EventDelegateBulkChangesStart();
    public delegate void EventDelegateBulkChangesEnd();
    
    // The "Things" that are stored in MyCustomDataSource
    
    public class Thing
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public object OtherStuff { get; set; }
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
    
        public event EventDelegateAdd AddingThing = delegate { };
        public event EventDelegateChange ChangingThing = delegate { };
        public event EventDelegateRemove RemovingThing = delegate { };
    
        public event EventDelegateBulkChangesStart BulkChangesStart = delegate { };
        public event EventDelegateBulkChangesEnd BulkChangesEnd = delegate { };
    
        private IObservable<Thing> _adds;
        private IObservable<Thing> _changes;
        private IObservable<Thing> _removes;
    
        private ReplaySubject<IList<Tuple<Thing,ThingEventType>>> _replayer;
        private IObservable<IList<Tuple<Thing,ThingEventType>>> _buffer;
        CompositeDisposable _disposables;
        
        public MyEventCachingBridge(MyCustomDataSource source, int eventRelayInterval)
        {
            _disposables = new CompositeDisposable();
            mSource = source;
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
            _adds = Observable.FromEvent<EventDelegateAdd, Thing>(
                ev => new EventDelegateAdd(ev),
                h => mSource.AddingThing += h,
                h => mSource.AddingThing -= h);
            _changes = Observable.FromEvent<EventDelegateChange, Thing>(
                ev => new EventDelegateChange(ev),
                h => mSource.ChangingThing += h,
                h => mSource.ChangingThing -= h);
            _removes = Observable.FromEvent<EventDelegateRemove, Thing>(
                ev => new EventDelegateRemove(ev),
                h => mSource.RemovingThing += h,
                h => mSource.RemovingThing -= h);
                            
            _buffer = Observable.Merge(
                        _adds.Select(e => Tuple.Create(e, ThingEventType.Add)), 
                        _changes.Select(e => Tuple.Create(e, ThingEventType.Change)), 
                        _removes.Select(e => Tuple.Create(e, ThingEventType.Remove)))
                .Buffer(TimeSpan.FromMilliseconds(eventRelayInterval));
                
            _replayer = new ReplaySubject<IList<Tuple<Thing, ThingEventType>>>();
            _disposables.Add(_buffer.Subscribe(_replayer));
        }
    
        public void PlayBackCachedEvents()
        {
            BulkChangesStart();   // Raise Event to notify GUI to suspend screen updates
    
            // Play back the list of events to push changes to ListView, TreeView, graphs, etc...
            foreach (var batch in _replayer.ToEnumerable())
            {
                foreach(var evt in batch)
                {
                    switch(evt.Item2)
                    {
                        case ThingEventType.Add: this.AddingThing(evt.Item1);break;
                        case ThingEventType.Change: this.ChangingThing(evt.Item1);break;
                        case ThingEventType.Remove: this.RemovingThing(evt.Item1);break;
                    }
                }
            }
            BulkChangesEnd();   // Raise Event to notify GUI to allow control refresh
        }
        
        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
