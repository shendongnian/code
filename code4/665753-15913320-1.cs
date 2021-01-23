    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    try
    {
        // do whatever
    }
    catch(Exception ex)
    {
         // Log an error with an exception
         log.Error("Exception thrown", ex);
    }
