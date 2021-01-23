    static void CloseAllChromeBrowsers()
    {
        foreach (Process process in Process.GetProcessesByName("chrome"))
        {
            if (process.MainWindowHandle == IntPtr.Zero) // some have no UI
                continue;
    
            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element != null)
            {
                ((WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern)).Close();
            }
        }
    }
