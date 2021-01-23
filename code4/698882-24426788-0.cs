    public static string GetSystem32DirectoryPath()
    {
        string winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        string system32Directory = Path.Combine(winDir, "system32");
        if (Environment.Is64BitOperatingSystem && !Environment.Is64BitProcess)
        {
            // For 32-bit processes on 64-bit systems, %windir%\system32 folder
            // can only be accessed by specifying %windir%\sysnative folder.
            system32Directory = Path.Combine(winDir, "sysnative");
        }
        return system32Directory;
    }
