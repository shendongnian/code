    using System.Threading;
    public static void RunInThread<TProgress>(
        Action<Action<TProgress>> worker,
        Action<TProgress> updateProgress,
        Action workerCompleted)
    {
        Thread workerThread = new Thread(() =>
        {
            worker(updateProgress);
            workerCompleted();
        });
        workerThread.Start();
    }
