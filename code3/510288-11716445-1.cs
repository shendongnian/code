    private void frmMain_Load(object sender, EventArgs e)
    {
        //---------------------------------------------
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        t.Tick +=new EventHandler(t_Tick);
        t.Interval = 1000;
        t.Start();
    }
    void t_Tick(object sender, EventArgs e)
    {
        frmLogin l = new frmLogin();
        if (l.ShowDialog(this) == DialogResult.Ok)
           ((System.Windows.Forms.Timer)sender.Dispose();
    }
