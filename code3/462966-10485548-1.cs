    public static LogMethod(string user, string message, params object[] parameters)
    {
        string methodName = new StackFrame(1).GetMethod().Name;
        ...      
    }
