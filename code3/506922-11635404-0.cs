    public static void Close()
    {
        lock (locker)
        {
            instanceCaller.Join();
            if (instance != null && !instance.IsClosed)
            {
                waitFormStarted.WaitOne();
                instance.FinalizeWork();
                instance.Dispatcher.Invoke(
                    new Action(() =>
                    {
                        instance.Close();
                    }));
            }
        }
    }
