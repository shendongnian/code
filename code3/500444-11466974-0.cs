    public void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new RunWorkerCompletedEventHandler(WorkerCompleted), new {sender, e});
        }
        else 
        {
            // Business logic goes here
        }
    }
