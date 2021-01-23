    void StopWork()
    {
        // CancellationTokenSource implements IDisposable.
        using (wtoken)
        {
            // Cancel.  This will cancel the task.
            wtoken.Cancel();
        }
        // Set everything to null, since the references
        // are on the class level and keeping them around
        // is holding onto invalid state.
        wtoken = null;
        task = null;
    }
