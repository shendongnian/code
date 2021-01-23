    private static object _dbLock = new object();
    private static ManualResetEvent _mrse = new ManualResetEvent(true);
    
    public static void LoadData()
    {
    
       lock (_dbLock)
       {
          _mrse.Reset();
          //Load data from the database
          _mrse.Set();
       }
    }
    
    public static string ReadData(Guid key)
    {
        _mrse.Wait();
        //Lookup key in data and return value
    }
