    BackgroundWorker _worker;
    private void button1_Click(object sender, EventArgs e)
    {
        _worker.RunWorkerAsync();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        _worker = new BackgroundWorker();
        _worker.WorkerReportsProgress = true;
        _worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        _worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = (BackgroundWorker)sender;
        for (int i = 0; i < 10; i++)
        {
            // pass value in parameter userState (2nd parameter), since it can hold objects
            worker.ReportProgress(0, i); // calls ProgressChanged on main thread
        }
    }
    void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        // get value, passed in DoWork, back from UserState
        textBox1.Text = textBox1.Text + (int)e.UserState;
    }
