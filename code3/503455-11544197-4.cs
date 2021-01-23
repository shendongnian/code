    try
    {
        ThrowAnException();
    }
    catch(Exception ex)
    {
        LoggingWrapper.Error(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace);
    }
