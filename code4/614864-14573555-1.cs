    private void WorkerThred()
    {
        try
        {
            DoWork();
        }
        catch (ThreadInterruptedException)
        {
            DisposeResources();
        }
    }
