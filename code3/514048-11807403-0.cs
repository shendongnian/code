    System.Diagnostics.StackFrame stackFrame = new System.Diagnostics.StackFrame();
     System.Reflection.MethodBase methodBase = stackFrame.GetMethod();
    
     methodBase.GetParameters(); //Array of System.Reflection.ParameterInfo[]
     methodBase.GetMethodBody().LocalVariables; //List of Local variables declared in the body
