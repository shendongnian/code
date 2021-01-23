    private static void RaisePrintEvent(string e)
    {
        var handler = Print;
        if (handler != null)
        {
            handler(e);
        }
    }
