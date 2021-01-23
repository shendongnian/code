    public class TraceEntryQueue
    {
        private readonly ObservableCollection<TraceEntry> _logEntries; 
        public TraceEntryQueue()
        {
            _logEntries = new ObservableCollection<TraceEntry>();
        }
        public void AddEntry(TraceEntry newEntry)
        {
            _logEntries.Add(newEntry);
        }
        public ObservableCollection<TraceEntry> GetLogEntries()
        {
            return _logEntries;
        }
    }
