    long time=0;
    bool b = Task.Factory
                .StartNew(() => time = ExecutionTime(LongRunningTask))
                .Wait(5000);
    if (b == false)
    {
        MessageBox.Show("Execution took more than 5 seconds.");
    }
    //time contains the execution time in msec.
---
    public long ExecutionTime(Action action)
    {
        var sw = Stopwatch.StartNew();
        action();
        return sw.ElapsedMilliseconds;
    }
    public void LongRunningTask()
    {
        Thread.Sleep(10000);
    }
