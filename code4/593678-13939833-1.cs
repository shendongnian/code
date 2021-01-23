        static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        try
        {
        //your code
        }
        catch (Exception ex)
        {
        logger.Error(ex.Message + System.Reflection.MethodBase.GetCurrentMethod());
        }
