    private Timer myTimer;
    private void DoSomething()
    {
        if (myTimer != null)
        {
            myTimer.Dispose();
            myTimer = null;
        }
        Method1();
        myTimer = new Timer(CheckForProcess, null, 100, 100);
    }
    private void CheckForProcess(object state)
    {
        bool isOpened = false;
        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (clsProcess.ProcessName.Contains("AdobeARM"))
            {
                isOpened = true;
                break;
            }
        }
        //Once the pop up from Method 1 comes i call other methods     
        if (isOpened)
        {
            myTimer.Dispose();
            myTimer = null;
            Method2();
            Method3();
            Method4();
        }
    }
