    string s = GetMainModuleFilepath(2011);
.  
    
    private string GetMainModuleFilepath(int processId)
    {
        string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
        using (var searcher = new ManagementObjectSearcher(wmiQueryString))
        {
            using (var results = searcher.Get())
            {
                ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                if (mo != null)
                {
                    return (string)mo["ExecutablePath"];
                }
            }
        }
        return null;
    }
