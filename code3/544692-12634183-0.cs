    public void DoWork(CancellationToken cancelToken)
    {
        try
        {
            //do work
            cancelToken.ThrowIfCancellationRequested();
            //more work
        }
        catch (OperationCanceledException) {}
        catch (Exception ex)
        {
            Log.Exception(ex);
        }
    }
