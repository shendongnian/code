    private static bool GetIdleFile(string path)
    {
        var fileIdle = false;
        const int MaximumAttemptsAllowed = 30;
        var attemptsMade = 0;
        while (!fileIdle && attemptsMade <= MaximumAttemptsAllowed)
        {
            try
            {
                using (File.Open(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    fileIdle = true;
                }
            }
            catch
            {
                attemptsMade++;
                Thread.Sleep(100);
            }
        }
 
        return fileIdle;
    }
