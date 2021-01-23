    public class TraceEntryQueue
    {
        private readonly Queue<TraceEntry> _logEntries; 
        private readonly ICollectionView _logEntriesView; 
        public TraceEntryQueue()
        {
            _logEntries = new Queue<TraceEntry>();
            _logEntriesView = CollectionViewSource.GetDefaultView(logEntries.ToList());
        }
        //....
        public void AddEntry(TraceEntry newEntry)
        {
            _logEntries.Enqueue(newEntry);
            _logEntriesView.SourceCollection = logEntries.ToList();
            _logEntriesView.Refresh();
        }
        public ICollectionView GetAsView()
        {
            return _logEntriesView;
        }
    }
