    private void AdminRelauncher()
    {
        if (!IsRunAsAdmin())
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Assembly.GetEntryAssembly().CodeBase;
            proc.Verb = "runas";
            try
            {
                Process.Start(proc);
                Application.Current.Shutdown();
            }
            catch(Exception ex)
            {
                Console.WriteLine("This program must be run as an administrator! \n\n" + ex.ToString());
            }
        }
    }
    private bool IsRunAsAdmin()
    {
        WindowsIdentity id = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(id);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
