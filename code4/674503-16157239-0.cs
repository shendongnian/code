    // During update process:
    if (!IsAdministrator()) 
    {
        // Launch itself as administrator
        ProcessStartInfo proc = new ProcessStartInfo();
        proc.UseShellExecute = true;
        proc.WorkingDirectory = Environment.CurrentDirectory;
        proc.FileName = Application.ExecutablePath;
        proc.Verb = "runas";
    
        try
        {
            Process.Start(proc);
        }
        catch
        {
            // The user refused to allow privileges elevation.
            // Do nothing and return directly ...
            return false;
        }
        Application.Exit();
    }
    public static bool IsAdministrator()
    {
        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
