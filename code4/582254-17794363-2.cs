    bool IsWindows8OrNewer()
    {
        var os = Environment.OSVersion;
        return os.Platform == PlatformID.Win32NT && 
                              (os.Version.Major > 6 || (os.Version.Major == 6 && os.Version.Minor >= 2));
    }
