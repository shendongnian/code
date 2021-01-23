    static void Main()
    {
        Mutex m = GetMutex();
        try
        {
           Program.Run();
        }
        finally
        {
            ((IDisposable)m).Dispose();
        }
    }
