    private static Mutex Mutex1 = new Mutex(false, "54A8F2C1-6C11-4ED4-8A62-AD7C1D9F7970");
    private static Mutex Mutex2 = new Mutex(false, "5E1C76D0-9897-412B-BD56-64A872F8FDE3");
    private static Mutex AcquiredMutex;
    public static bool StartInstance()
    {
        if (AcquiredMutex != null)
            return true;
        if (Mutex1.WaitOne(1))
        {
            AcquiredMutex = Mutex1;
        }
        else if (Mutex2.WaitOne(1))
        {
            AcquiredMutex = Mutex2;
        }
        return (AcquiredMutex != null);
    }
    public static void StopInstance()
    {
        if (AcquiredMutex != null)
            AcquiredMutex.ReleaseMutex();
    }
