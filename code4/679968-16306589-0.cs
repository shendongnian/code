    timer.Tick += new EventHandler(timer_Tick);
    timer.Interval = (1000) * (2);             
    timer.Enabled = true;                       
    timer.Start();
    void timer_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] pname =   System.Diagnostics.Process.GetProcessesByName("mstsc");
            if (pname.Length != 0)
            {
                 
            }
            else
            {
            System.Diagnostics.Process.Start(@"mstsc.exe");
            }
        }
