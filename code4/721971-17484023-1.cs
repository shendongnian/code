    public long PerformanceCounter()
    {
        long result;
        QueryPerformanceCounter(out result);
        return result;
    }
    [DllImport("kernel32.dll", SetLastError=true)]
    static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
