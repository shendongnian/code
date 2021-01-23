    public string GetTestMethodName()
    {
        try
        {
            // for when it runs via TeamCity
            return TestContext.CurrentContext.Test.Name;
        }
        catch
        {
            // for when it runs via Visual Studio locally
            var stackTrace = new StackTrace(); 
            foreach (var stackFrame in stackTrace.GetFrames())
            {
                MethodBase methodBase = stackFrame.GetMethod();
                Object[] attributes = methodBase.GetCustomAttributes(
                                          typeof(TestAttribute), false); 
                if (attributes.Length >= 1)
                {
                    return methodBase.Name;
                }
            }
            return "Not called from a test method";  
        }
    }
