    private static string GetCallingMethodName()
    {
       const int iCallDeepness = 0; //can vary this ...
       System.Diagnostics.StackTrace stack = new System.Diagnostics.StackTrace(false);
       System.Diagnostics.StackFrame sframe = stack.GetFrame(iCallDeepness);
       return sframe.GetMethod().Name;
    }
