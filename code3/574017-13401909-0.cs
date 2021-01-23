    FileInfo fi = new FileInfo("myLogFile.txt");
    StreamWriter _sw;
    void Main()
    {
        _sw = fi.CreateText();
        _sw.AutoFlush = true;
        Trace.Listeners.Add(new TextWriterTraceListener(sw));
    }
    void Close()
    {
        if(_sw != null)
        {
            _sw.Flush();
            _sw.Dispose();
        }
    }
