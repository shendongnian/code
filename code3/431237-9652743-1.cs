    public void MyMethod(Notifier not)
    { 
        if(not.HasValue())
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            throw new Exception(methodName + ": " + not.Value);
        }
    } 
