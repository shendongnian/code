    private static readonly string[] MutexNames = new string[]
    {
        "54A8F2C1-6C11-4ED4-8A62-AD7C1D9F7970",
        "5E1C76D0-9897-412B-BD56-64A872F8FDE3"
    };
    private static Mutex CreatedMutex;
    public static bool StartInstance()
    {
        if (CreatedMutex != null)
            return true;
        foreach (string name in MutexNames)
        {
            bool created;
            Mutex mutex = new Mutex(false, name, out created);
            if (created)
            {
                CreatedMutex = mutex;
                return true;
            }
            else
            {
                mutex.Close();
            }
        }
        return false;
    }
    public static void StopInstance()
    {
        if (CreatedMutex != null)
            CreatedMutex.Close();
    }
