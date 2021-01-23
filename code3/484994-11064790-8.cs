    private const int WM_QUERYENDSESSION = 0x11;
    private const int WM_CANCELMODE = 0x1f;
    private bool shutdownRequested = false;
    
    ...
    
    protected override void WndProc(ref Message ex)
    {
        if (ex.Msg == WM_QUERYENDSESSION)
        {
            Message MyMsg = new Message();
            MyMsg.Msg = WM_CANCELMODE;
            base.WndProc(ref MyMsg);
            this.shutdownRequested = true;
        }
        else
        {
            base.WndProc(ex);
        }
    }
    
    ...
    
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        this.Visible = false; // optional
        this.ShowInTaskbar = false; // optional
        Task db = Task.Factory.StartNew(() => DBUpdate();
        Task.WaitAll(db); // you can have more tasks like the one above
        if (this.shutdownRequested)
            Process.Start("shutdown.exe","-s");
    }
    
    private void DBUpdate()
    {
        // write your db code here
    }
