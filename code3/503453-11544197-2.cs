    public static void LogException(Exception ex)
    {
        logger = LogManager.GetLogger("NHibernate.SQL");
        logger.Error(ex.Message + Environment.NewLine + ex.InnerException + Environment.NewLine + ex.StackTrace, ex);
    }
