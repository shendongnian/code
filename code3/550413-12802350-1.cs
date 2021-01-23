    public void BlockingMethod()
    {
        taskFactory
            .StartNew(() => { /* Do work. */ })
            .Wait();
    }
