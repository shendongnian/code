    private static readonly ConcurrentDictionary<string, object> _processes = new ConcurrentDictionary<string, object>();
    private static readonly object _dictionaryLock = new object();
    public void DeserializeXml(Guid xml_Id, decimal version)
    {
        string processKey = string.Format("{0}_v{1}", xml_Id, version.ToString("#0.0"));
        object processLocker = null;
        bool needsExecuting = false;
        lock (_dictionaryLock)
        {
          if (_processes.TryGetValue(processKey, out processLocker) == false)
          {
              needsExecuting = true;
              processLocker = new object();
              _processes.Add(processKey, processLocker);
          }
        }
        lock (processLocker)
        {
            if (needsExecuting)
            {
              // heavy process here which takes about 3 seconds
              _processes.Remove(processKey);
            }
        }
    }
