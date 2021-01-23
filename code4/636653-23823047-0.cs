    private void CustomMuTex() {
    string processName = Process.GetCurrentProcess().MainModule.ModuleName;
    ManagementObjectSearcher mos = new ManagementObjectSearcher();
    mos.Query.QueryString = @"SELECT * FROM Win32_Process WHERE Name = '" + processName + @"'";
    if (mos.Get().Count > 1)
        Console.WriteLine("Previous Process is already running...");
    }
