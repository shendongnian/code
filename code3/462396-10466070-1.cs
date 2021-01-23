    private static readonly object _printLock = new object();
    private static void RaisePrintEvent(string e)
    {
        lock(_printLock)
        {
            var handler = Print;
            if (handler != null)
            {
                handler(e);
            }
        }
    }
