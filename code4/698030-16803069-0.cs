    public Task Process()
    {
        worker = new Worker { date = date, dc = dc, despatchProcess = despatchProcess };
        return Task.Factory.StartNew( () => worker.process() );
    }
