    private Task _saveChangesTask;
    // Used to synchronize access to _saveChangesTask
    private readonly object _saveChangesTaskLock = new object();
    public void SaveChanges()
    {
        // Guard access to the reference.
        lock (_saveChangesTaskLock)
        {
            // Check and assign.
           if (_saveChangesTask != null) return;
 
            _saveChangesTask = ActionManager.StartAsyncTask(() =>
            { 
                // Save stuff here - slowly
                // Done saving stuff here - slowly
                // (BTW, is the above a reference from "True Lies"?)
                // Remove reference to task.  This is on another thread
                // so using a lock again is ok.
                // Guard access to the reference.
                lock (_saveChangesTaskLock) _saveChangesTask = null;
            });
        }
    }
