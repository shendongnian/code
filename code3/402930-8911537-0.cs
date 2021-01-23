    public string StartProcess(object state)
    {
        ThreadResult result = (ThreadResult)state;
        result.Result = PerformSomething();
    }
