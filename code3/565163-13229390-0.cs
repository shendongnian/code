    public static void Info(string strMsg)
    {
        StackTrace st = new StackTrace(true);
        StackFrame sf = st.GetFrame(1);
        _log.Info(string.Format("{0,-25} L{1:0000} {2}", sf.GetFileName().Substring(sf.GetFileName().LastIndexOf(@"\") + 1), sf.GetFileLineNumber(), strMsg));
    }
