    public class IntervalChangeReader
    {
        // My state between ticks.
        private IEnumerable<SomeEntity> knowEntities;
    
        // Reads the data from the db and uses knowEntities to determine adds, changes, 
        // and deletes which are exposed through properties.
        private DbReaderAndChangeChecker checker;
    
        private EntityChangeSet lastChangeResult;
        public IntervalChangeReader(DbReaderAndChangeChecker checker)
        {
            this.checker = checker;
            // I like to use Do instead of just combining this all into Select to make the side effect obvious.
            this.Changes = Observable.Interval(TimeSpan.FromSeconds(seconds), scheduler).Do(
                x =>
                    {
                        var changes = DbReaderAndChangeChecker.Refresh(this.knownXRefs);
        
                        // Make changes to knownXRefs which is my state.
                        this.knownXRefs.AddRange(changes.Added);
                        this.knownXRefs.RemoveAll(y => changes.Removed.Any(z => z.Id == y.Id));
                        this.knownXRefs.RemoveAll(y => changes.Changed.Any(z => z.Id == y.Id));
                        this.knownXRefs.AddRange(changes.Changed);
                        lastChangeResult = changes;
                    }).Select(x => this.lastChangeResult);
                }
    
        public IObservable<EntityChangeSet> Changes { get; private set; }
    
    }
