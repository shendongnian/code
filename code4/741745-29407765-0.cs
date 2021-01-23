    string sid = string.Empty; 
    using (var mos = new ManagementObjectSearcher(
                            "Select SID From Win32_UserAccount where Disabled = 0"))
    {
        foreach (var bios in mos.Get())
        {
            sid = bios["SID"].ToString();
        }
    }
    using (RegistryKey key = Registry.Users.OpenSubKey(sid +
    @"\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"))
    {
        var docFolder = key.GetValue("Personal");
        var desktopFolder = key.GetValue("Desktop");
        Console.WriteLine("document folder: {0}", docFolder);
        Console.WriteLine("Desktop folder: {0}", desktopFolder);
    }
