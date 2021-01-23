    public static bool IsApplicationAlreadyRunning(string ApplicationName)
        {
        bool isNewMutexCreated;
        mutex = new Mutex(true, "Global\\" + ApplicationName", out isNewMutexCreated);
        if (isNewMutexCreated)
        {
            //Here we can decide to wait in loop to execute first application
            mutex.ReleaseMutex();
        }
        return !isNewMutexCreated;
    }
