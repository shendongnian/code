    Microsoft.Office.Interop.Excel.Application xlsApp;
    Process xlsProcess;
    Timer timer;
    public Form1()
    {
        xlsApp = new Microsoft.Office.Interop.Excel.Application();
        xlsApp.Visible = true;
        foreach (var p in Process.GetProcesses()) //Get the relevant Excel process.
        {
            if (p.MainWindowHandle == new IntPtr(xlsApp.Hwnd))
            {
                xlsProcess = p;
                break;
            }
        }
        if (xlsProcess != null)
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
    }
    void timer_Tick(object sender, EventArgs e)
    {
        if (xlsApp != null && !xlsApp.Visible)
        {
            //Clean up to make sure the background Excel process is terminated.
            xlsApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
            xlsApp = null;
        }
        if (xlsProcess.HasExited)
        {
            //The event is not fired but the property is eventually set once the process is terminated
            this.timer.Dispose();
            this.Close();
        }
    }
