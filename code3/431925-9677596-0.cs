    static ulong GetAvailableMemoryKilobytes()
    {
        const string memoryPropertyName = "FreePhysicalMemory";
        
        using (ManagementObject operatingSystem = new ManagementObject("Win32_OperatingSystem=@"))
            return (ulong) operatingSystem[memoryPropertyName];
    }
        
    static ulong GetTotalMemoryKilobytes()
    {
        const string memoryPropertyName = "TotalVisibleMemorySize";
        
        using (ManagementObject operatingSystem = new ManagementObject("Win32_OperatingSystem=@"))
            return (ulong) operatingSystem[memoryPropertyName];
    }
