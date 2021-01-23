    public string MyMethod()
    {
        StackTrace st = new StackTrace ();
        StackFrame sf = st.GetFrame (1);
        string methodName = sf.GetMethod().Name;
    }
