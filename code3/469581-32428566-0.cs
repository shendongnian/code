    public static string getHomePath()
    {
        // Not in .NET 2.0
        // System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
            return System.Environment.GetEnvironmentVariable("HOME");
        return System.Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
    }
    public static string getDownloadFolderPath()
    {
        if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
        {
            string pathDownload = System.IO.Path.Combine(getHomePath(), "Downloads");
            return pathDownload;
        }
        return System.Convert.ToString(
            Microsoft.Win32.Registry.GetValue(
                 @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders"
                ,"{374DE290-123F-4565-9164-39C4925E467B}"
                ,String.Empty
            )
        );
    }
