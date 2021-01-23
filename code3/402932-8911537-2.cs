    public void SomeMethodThatStartsTheThread()
    {
        ThreadResult myResult = new ThreadResult();
        Thread t = new Thread(new ParameterizedThreadStart(StartProcess));
        t.Start(myResult);
    
        // We can do other work while the thread is running
    }
    public string StartProcess(object state)
    {
        ThreadResult result = (ThreadResult)state;
        result.Result = PerformSomething();
        ThreadIsDone(result);
    }
    public void ThreadIsDone(ThreadResult result)
    {
        // Do stuff you want to do when the thread is done
    }
