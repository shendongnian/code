    // Usage:
    try
    {
        // boom
    }
    catch(Exception ex)
    {
        // Only log exception
        ex.Log();
        -- OR --
        // Only display exception
        ex.Display();
        -- OR --
        // Log, then display exception
        ex.Log().Display();
        -- OR --
        // Add some user-friendly message to an exception
        new ApplicationException("Unable to calculate !", ex).Log().Display();
    }
    // Extension methods
    internal static Exception Log(this Exception ex)
    {
        File.AppendAllText("CaughtExceptions" + DateTime.Now.ToString("yyyy-MM-dd") + ".log", DateTime.Now.ToString("HH:mm:ss") + ": " + ex.Message + "\n" + ex.ToString() + "\n");
        return ex;
    }
    internal static Exception Display(this Exception ex, string msg = null, MessageBoxImage img = MessageBoxImage.Error)
    {
        MessageBox.Show(msg ?? ex.Message, "", MessageBoxButton.OK, img);
        return ex;
    }
