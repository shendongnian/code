    public void MainProgramCall()
    {
        //......
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        var classWithLogger = new ClassWithLogger(log);
        classWithLogger.DoSomething(new object());
        //......
        classWithLogger.DoSomething();
        //......
    }
