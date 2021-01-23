    private static readonly HashSet<string> _processKeys = new HashSet<string>();
    private static object _processLocker = new object();
    public void DeserializeXml(Guid xml_Id, decimal version)
    {
        string processKey = string.Format("{0}_v{1}", xml_Id, version.ToString("#0.0"));
        lock (_processLocker)
        {
          if (_processKeys.Contains(processKey))
          { 
              return;
          }
          else
          {          
              _processKeys.Add(processKey);
          }
        }
        try 
        {
          // heavy process here which takes about 3 seconds
        }
        finally 
        {
          lock (_processLocker)
          {          
              _processKeys.Remove(processKey);
          }
        }
    }
