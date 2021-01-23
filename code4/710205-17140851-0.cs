    private Timer _Timer;
    private DateTime _Start;
    private void InitTimer()
    {
        _Start = DateTime.Now;
        _Timer = new Timer(100);
        _Timer.AutoReset = false;
        _Timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
        _Timer.Start();
    }
    private void Timer_Elapsed(object sender, ElapsedEventArgs  e)
    {
        TimeSpan diff = DateTime.Now - _Start;
        this.Invoke(new MethodInvoker(delegate()
        {
            lblProgress.Text = String.Format("Time: {0}", diff);
        }));
    }
    //starts the worker thread
    private void btnUpdate_Click(object sender, EventArgs e)
    {
        InitTimer();
        bgWorker.RunWorkerAsync();
    }
    //Does the backup
    private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackUpDatabase.BackUp(this.txtPath.Text);
    }
    //Stops the timer when the backup finishes
    private void bgWorker_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        _Timer.Stop();
    }
