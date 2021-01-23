    private static readonly ObservableCollection<TraceMessageInfo> _traceLogs;
    public ObservableCollection<TraceMessageInfo> TraceLogs
    {
        get
        {
            return _traceLogs;
        }
    }
    static CustomTraceListener()
    {
        _traceLogs = new ObservableCollection<TraceMessageInfo>();
        _traceLogs.Add(new TraceMessageInfo("Message", Enums.TraceCategory.Information.ToString()));
    }
