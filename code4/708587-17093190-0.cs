    private void WorkCompletedEventHandler(object sender, WorkCompletedEventArgs e)
    {
        stopPeriodicProcess.Reset();
        ThreadPool.RegisterWaitForSingleObject(stopPeriodicProcess,
                                               (state, timedOut) => DoPeriodicProcess(state, timedOut, e.EngineId), null,
                                               5000, true);
    }
