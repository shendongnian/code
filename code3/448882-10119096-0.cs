    private Mutex mut = new Mutex(); // Somewhere in mail class
    void WriteLog(string LogStr)
    {
        mut.WaitOne();
        try 
        {
            using(StreamWriter sw = new StreamWriter("Log.txt", true))
                sw.WriteLine(LogStr);
        } 
        finally 
        {
            mut.ReleaseMutex();
        }
    }
