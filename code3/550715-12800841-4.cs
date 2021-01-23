    public interface ILogItem
    {
        String GetLogData();
        LogType LogType { get; }
    }
    public void Log<T>(T item) 
        where T : ILogItem
    {
        Debug.WriteLine(item.GetLogData());
        // Read more data
        switch (item.LogType)
        { ... }
    }
