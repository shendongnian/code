    public static void RunInThread<TProgress, TParameter>(
        Action<Action<TProgress>, TParameter> worker,
        Action<TProgress> updateProgress,
        Action workerCompleted,
        TParameter parameter)
    {
        Thread workerThread = new Thread(() =>
        {
            worker(updateProgress, parameter);
            workerCompleted();
        });
        workerThread.Start();
    }
    public static void RunInThread<TProgress, TResult>(
        Func<Action<TProgress>, TResult> worker,
        Action<TProgress> updateProgress,
        Action<TResult> workerCompleted)
    {
        Thread workerThread = new Thread(() =>
        {
            TResult result = worker(updateProgress);
            workerCompleted(result);
        });
        workerThread.Start();
    }
    public static void RunInThread<TProgress, TParameter, TResult>(
        Func<Action<TProgress>, TParameter, TResult> worker,
        Action<TProgress> updateProgress,
        Action<TResult> workerCompleted,
        TParameter parameter)
    {
        Thread workerThread = new Thread(() =>
        {
            TResult result = worker(updateProgress, parameter);
            workerCompleted(result);
        });
        workerThread.Start();
    }
