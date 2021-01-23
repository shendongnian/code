    private Task m_task = null;
    private void DoTask()
    {
        try
        {
            m_task = Task.Factory.StartNew(() => this.StartPolling());
        }
        catch
        {
            this.Log.Error("Unable to start task", ex);
            throw;  // Rethrow, so that the OS knows, there was something wrong.
        }           
    }
    private void StartPolling()
    {
        try
        {
            this.OriginalFileProcessor.StartPolling();
        }
        catch (Exception ex)
        {
            this.Log.Error("Failed running the task", ex);
        }
    }
