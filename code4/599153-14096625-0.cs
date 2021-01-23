    private System.Threading.TimerCallback worker;
    private System.Threading.Timer workertimer ;
    private void worker_DoWork()
    {
       //You codes
    }
    private void StartWorker()
    {
       worker = new System.Threading.TimerCallback(worker_DoWork);
       workertimer = new System.Threading.Timer(worker, null, 1000, 1000);
    }
    
    private void CancelWorker()
    {
        worker.Dispose();
    }
