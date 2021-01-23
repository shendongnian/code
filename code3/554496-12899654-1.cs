    protected override void OnStart(string[] args)
    {
        ProcessingThread = new Thread(new ThreadStart(procClass.ThreadStartProc));
        ProcessingThread.Start();
    }
    protected override void OnStop()
    {
         if (ProcessingThread != null)
         {
              ProcessingThread.Abort();
              ProcessingThread.Join();
              ProcessingThread = null;
         }
    }
