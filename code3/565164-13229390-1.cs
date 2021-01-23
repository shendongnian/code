    public static void Debug(string strMsg)
    {
        StackTrace st = new StackTrace(true);
    #if DEBUG
        StackFrame sf = st.GetFrame(1);
        _log.Debug(string.Format("{0,-25} L{1:0000} {2}", sf.GetFileName().Substring(sf.GetFileName().LastIndexOf(@"\") + 1), sf.GetFileLineNumber(), strMsg));
    #else
        _log.Debug(string.Format("{0}",strMsg));
    #endif            
    }
