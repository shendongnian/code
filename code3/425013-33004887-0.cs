    public static void runAsAdmin(string[] args)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            if (args != null)
                proc.Arguments = string.Concat(args);
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            proc.Verb = "runas";
         
            bool isElevated;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (!isElevated)
            {
                try
                {
                    Process.Start(proc);
                }
                catch
                {
                    //No Admin rights, continue without them
                    return;
                }
                //Close current process for switching to elevated one
                Environment.Exit(0);
            }
            return;
        }
