    public void Run(DateTime runDate, ProcessCode process, LineOfBusinessCode lineOfBusinessCode, LineOfBusinessHandler del)
    {
        this.DoRun(runDate, process, (d, p) => del(d, p, lineOfBusinessCode));
    }
    public void DoRun(DateTime runDate, ProcessCode process, Action<DateTime, ProcessCode> action)
    {
        this.ProcessManager.AddToBatchLog(process.ToString(), ProcessStatus.Started.ToString(), null, runDate);
        try
        {
            action(runDate, process);
            this.ProcessManager.AddToBatchLog(process.ToString(), ProcessStatus.Finished.ToString(), null, runDate);
        }
        catch (Exception e)
        {
            int errorId = SystemManager.LogError(e, process.ToString());
            this.ProcessManager.AddToBatchLog(process.ToString(), ProcessStatus.Errored.ToString(), errorId, runDate);
        }
    }
