    private void YouCalledMethod()
    {
        StackTrace stackTrace = new StackTrace();
        StackFrame stackFrame = stackTrace.GetFrame(1);
        Assembly assembly = stackFrame.GetMethod().DeclaringType.Assembly;
        //use this assembly object for your requirement.
    }
