    BackgroundWorker_DoWork(sender, )
    {
        try
        {
           // do work        
        }
        catch (Exception ex)
        {
             BackgroundWorker w = sender as BackgroundWorker;
             if (w != null)
                 w.Result = ex;
        }
    }
