    private void GetPRo()
    {
        if (label1.Text == ("complete"))
        {
            bool prc = false;
            while (!prc)
            {
                foreach (Process clsProcess in Process.GetProcesses())
                {
                    if (clsProcess.ProcessName.Contains("JS_plugin"))
                    {
                        prc = true;
                        Application.Exit();
                    }
                }
            }
        } 
    }
.
            
    Thread CloseApp = new Thread(new ThreadStart(GetPro));
    CloseApp.Start();
