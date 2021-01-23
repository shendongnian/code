    private static string GetCallingMethodName()
    {        
        const int iCallDeepness = 2; 
        System.Diagnostics.StackTrace stack = new System.Diagnostics.StackTrace(false);
        System.Diagnostics.StackFrame sframe = stack.GetFrame(iCallDeepness);
        return sframe.GetMethod().Name;
    }
