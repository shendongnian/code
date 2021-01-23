    BackgroundWorker _worker=new BackgroundWorker();
    void OnMessage(int lparam, int wparam)
    {
        frame frame=GetFrame();
       if(!_worker.IsBusy)
            _worker.RunWorkerAsync(frame);
    }
    void DoWork(object sender,DoWorkEventArgs e)
    {
        //do processing
    }
