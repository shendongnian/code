    [DllImport("user32.dll", CharSet=CharSet.Auto,ExactSpelling=true)]
    public static extern IntPtr SetFocus(HandleRef hWnd);
    
    
    [TestMethod]
    public void PlayAround()
    {
        Process[] processList = Process.GetProcesses();
    
        foreach (Process theProcess in processList)
        {
            string processName = theProcess.ProcessName;
            string mainWindowTitle = theProcess.MainWindowTitle;
            SetFocus(new HandleRef(null, theProcess.MainWindowHandle));
        }
    
    }
