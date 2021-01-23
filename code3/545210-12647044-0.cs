    using (ManagementObjectSearcher s = new ManagementObjectSearcher("SELECT * FROM Win32_Service"))
    {
        using (ManagementObjectCollection items = s.Get())
        {
            ManagementObject item = items.Cast<ManagementObject>().Last();
            //do stuff
        }
    }
