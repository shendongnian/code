    try
    {
        log.Info("this works");
        throw new System.ArgumentException("Keith Nicholas Test");
    }
    catch (Exception e)
    {
       log.Info("nothing here", e);
    }
