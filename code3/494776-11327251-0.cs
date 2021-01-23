    private void backgroundWorker1_RunWorkerCompleted(
        object sender, RunWorkerCompletedEventArgs e)
    {
        // First, handle the case where an exception was thrown.
        if (e.Error != null)
        {
            throw new SomeException("... message ...", e.Error);
        }
        ...
    }
