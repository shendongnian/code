    private static Type GetCallingMethodHolderType()
    {
       const int iCallDeepness = 0; //can vary this ...
       System.Diagnostics.StackTrace stack = new System.Diagnostics.StackTrace(false);
       System.Diagnostics.StackFrame sframe = stack.GetFrame(iCallDeepness);
       return sframe.GetMethod().ReflectedType; //This will return a TYPE which holds the method.
    }
