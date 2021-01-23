    public class TraceEntryQueue : INotifyCollectionChanged
    {
        private readonly Queue<TraceEntry> _logEntries;
        public TraceEntryQueue()
        {
            _logEntries = new Queue<TraceEntry>();
        }
        public void AddEntry(TraceEntry newEntry)
        {
            _logEntries.Enqueue(newEntry);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newEntry));
        }
        public List<TraceEntry> GetAsList()
        {
            return _logEntries.ToList();
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, e);
            }
        }
    }
