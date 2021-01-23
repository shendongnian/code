    private void frmMain_Load(object sender, EventArgs e)
    {
       //---------------------------------------------
       System.Timers.Timer t = new System.Timers.Timer(1000);
       t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
       t.Start();
    }
    void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        frmLogin l = new frmLogin();
        if (l.ShowDialog() == DialogResult.Ok)
           ((System.Timers.Timer)sender.Dispose();
    }
