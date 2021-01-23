    public string MyMethod(string arg)
    {
        string result = null;
        if (logger.IsDebugEnabled) logger.Debug("->MyMethod(" + arg + ")");
        // do stuff
        result = "Hello world!";
        if (logger.IsDebugEnabled) logger.Debug("<-MyMethod(" + arg + ") = " + result);
        return result;
    }
