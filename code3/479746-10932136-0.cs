    while (!myTask.IsCompleted)
    {
        Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
        System.Threading.Thread.Sleep(20);
    }
