    private bool _Paused = false;
    private void OnPauseClick()
    {
        _Paused = true;
    }
    private void OnResumeClick()
    {
        _Paused = false;
    }
    private void OnRunClick()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(WorkerMethod));
    }
    
    private void WorkerMethod(object state)
    {
        ...
        while (needToDoMoreWork)
        {
            // do some work here
            ...
            // if pause requested, wait to unpause
            while (_Paused)
            {
                // Sleep for a short time and check again if paused
                Thread.Sleep(100);
            }
        }
    }
