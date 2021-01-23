    public void Start()
    {
        if (started) {
            return;
        }
        started = true;
        new Thread (new ThreadStart (() => {
            while (processingQueue) {
                var request = GetRequest();
                if (op != null) {
                    op.State = OperationState.InRequest;
                    Download (op);
                } else {
                    Thread.Sleep (AppSettings.OperationQueueDelay);
                }
            }
        })).Start ();
    }
    public void Stop()
    {
        started = false;
    }
