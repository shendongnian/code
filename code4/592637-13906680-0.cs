    private void Form1_Load(object sender, EventArgs e)
    {
        var bw = new BackgroundWorker();
        bw.DoWork += bw_DoWork;
        bw.RunWorkerAsync(); //Start the worker
    }
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        throw new NotImplementedException(); //remove this
    }
