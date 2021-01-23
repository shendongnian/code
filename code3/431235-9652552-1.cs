    public void MyMethod(Notifier not)
    { 
      StackFrame stackFrame = new StackFrame();
      MethodBase methodBase = stackFrame.GetMethod();
   
      if(not.HasValue())
          throw new Exception("MyMethod_name : " + methodBase.Name);
    }   
