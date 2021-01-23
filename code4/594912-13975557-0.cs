    public static async Task RunAsync(Action backgroundWork, Action uiWork, Action<Exception> exceptionWork)
    {
      try
      {
        // The time consuming work is run on a background thread.
        await Task.Run(backgroundWork);
        // The UI work is run on the UI thread.
        uiWork();
      }
      catch (Exception ex)
      {
        // Exceptions in the background task and UI work are handled on the UI thread.
        exceptionWork(ex);
      }
    }
