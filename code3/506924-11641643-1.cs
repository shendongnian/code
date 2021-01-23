    //synchronizer
    private static QueueSynchronizer queueSynchronizer;
    
    private static Thread instanceCaller;
    private static WaitForm instance;
    
    private static AutoResetEvent waitFormStarted = new AutoResetEvent(false);
    private static object locker = new object();
    
    /// <summary>
    /// Initializes WaitForm to start a single task
    /// </summary>
    /// <param name="header">WaitForm header</param>
    /// <param name="message">Message displayed</param>
    /// <param name="showProgressBar">True if we want a progress bar, else false</param>
    public static void Start(string header, string message, bool showProgressBar)
    {
        queueSynchronizer = new QueueSynchronizer();
        InitializeCallerThread(showProgressBar, header, message);
        instanceCaller.Start();
    }
    
    /// <summary>
    /// Initializes caller thread for executing a single command
    /// </summary>
    /// <param name="showProgressBar"></param>
    /// <param name="header"></param>
    /// <param name="message"></param>
    private static void InitializeCallerThread(bool showProgressBar, string header, string message)
    {
        waitFormStarted.Reset();
    
        instanceCaller = new Thread(() =>
        {
            lock (locker)
            {
                //Queuing to run on first.
                Mutex mx = queueSynchronizer.Sincronize(1);
                try
                {
                    instance = new WaitForm()
                            {
                                Header = header,
                                Message = message,
                                IsProgressBarVisible = showProgressBar
                            };
                }
                finally
                {
                    //I think is here that ends the first step!?
                    mx.ReleaseMutex();
                }
    
                waitFormStarted.Set();
            }
            instance.ShowDialog();
        });
        instanceCaller.Name = "WaitForm thread";
        instanceCaller.SetApartmentState(ApartmentState.STA);
        instanceCaller.IsBackground = true;
    }
    
    /// <summary>
    /// Closes current form
    /// </summary>
    public static void Close()
    {
        //Queuing to run on second.
        Mutex mx = queueSynchronizer.Sincronize(2);
        try
        {
            lock (locker)
            {
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
        finally
        {
            mx.ReleaseMutex();
        }
    }
