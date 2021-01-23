    public static void CheckAndRun()
    {
        if (ScreenSaverCheck.IsScreenSaverRunning() == true)
        {
            if (InternetCheck.IsConnected() == false)
            {
                string FirefoxBinary = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\firefox.exe", null, false);
                using (Process LaunchMacro = new Process())
                {
                    LaunchMacro.StartInfo.FileName = FirefoxBinary;
                    LaunchMacro.StartInfo.Arguments = "imacros://run/?m=RebootRouter.iim";
                    LaunchMacro.Start();
                }
            }
        }
    }
