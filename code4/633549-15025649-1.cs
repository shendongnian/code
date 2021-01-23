    // Returns true if the wait was successful.
    // Once this has returned true, it will return false until the file is created again.
    public static bool WaitForFileToBeCreated(int timeoutMilliseconds) // Pass Timeout.Infinite to wait infinitely.
    {
        using (EventWaitHandle readySignaller = new EventWaitHandle(false, EventResetMode.ManualReset, "MySignalName"))
        {
            bool result = readySignaller.WaitOne(timeoutMilliseconds);
            if (result)
            {
                readySignaller.Reset();
            }
            return result;
        }
    }
