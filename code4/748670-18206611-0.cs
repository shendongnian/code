    public void DoSomething()
    {
        StackFrame CallerFrame;
        StackTrace CallStack;
        int CodeOffset;
        MethodBody MethodBody;
        int MethodToken;
        int TokenIDecoy;
        int TokenITest;
        // Get the metadata tokens for both interface methods
        TokenIDecoy = Type.GetType("Proto.SO18203446.IDecoy").GetMethod("DoSomething").MetadataToken;
        TokenITest = Type.GetType("Proto.SO18203446.ITest").GetMethod("DoSomething").MetadataToken;
        // Get the caller
        CallStack = new StackTrace();
        CallerFrame = CallStack.GetFrame(1);
        // Get the metadata token called by the IL
        CodeOffset = CallerFrame.GetILOffset();
        MethodBody = CallerFrame.GetMethod().GetMethodBody();
        MethodToken = BitConverter.ToInt32(MethodBody.GetILAsByteArray(), CodeOffset - 4);
        // Check to see which interface was used
        if (MethodToken == TokenIDecoy)
            Console.WriteLine("IDecoy was called");
        else if (MethodToken == TokenITest)
            Console.WriteLine("ITest was called");
        else
            Console.WriteLine("Not sure what happened here");
    }
