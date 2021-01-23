    public void Run<T1>(DateTime runDate, ProcessCode process, T1 param1, Action<DateTime, ProcessCode, T1> del)
    {
        this.DoRun(runDate, process, (d, p) => del(d, p, param1));
    }
    public void Run<T1, T2>(DateTime runDate, ProcessCode process, T1 param1, T2 param2, Action<DateTime, ProcessCode, T1, T2> del)
    {
        this.DoRun(runDate, process, (d, p) => del(d, p, param1, param2));
    }
