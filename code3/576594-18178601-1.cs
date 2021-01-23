    public static void EventLogWrite(MethodBase methodBase, string zErrorMessage)
    {
        string classname = methodBase.DeclaringType.Name;
        string methodname = methodBase.Name;
    
        string logmessage = String.Concat(classname, ".", methodname, " : ", zErrorMessage);
    
        // ... write message to event log file
    }
