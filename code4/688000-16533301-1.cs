    private static Object _mylock = new Object();
    public static void LogMessageToFile(string msg)
    {
        lock(_mylock)
        {
           msg = string.Format("{0:G}: {1}{2}", DateTime.Now, msg, Environment.NewLine);
           File.AppendAllText(LOG_FULLPATH, msg);
        }
    }
