    System.Threading.Timer uploadTimer = new Timer(
        UploadProc, null, TimeSpan.FromSeconds(15), TimeSpan.FromMilliseconds(-1));
    void UploadProc(object state)
    {
        // processing here
        // now reset the timer
        uploadTimer.Change(TimeSpan.FromSeconds(15), TimeSpan.FromMilliseconds(-1));
    }
